// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Explosion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
	    _GlitchTex("GlitchTex", 2D) = "white" {}
		_DissolveTex("DissolveTex", 2D) = "white" {}
		_Color("Color", Color) = (1.0, 1.0 ,1.0 ,1.0)
		_Frequency("Frequency", float) = 0.0
		_Cutoff("Cutoff", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
		Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _GlitchTex_ST;

			sampler2D _GlitchTex;
			sampler2D _DissolveTex;
			fixed4 _Color;
			float _Frequency;
			float _Cutoff;

			v2f vert(appdata_base v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv *= sin(1.0 * _Time.w * o.uv ) + 1;
				return o;
			}

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv + _Cutoff);
				fixed4 glitch = tex2D(_GlitchTex, i.uv); 
				fixed4 dissolve = tex2D(_DissolveTex, i.uv); //

				col.a *= sin(_Frequency * 100.0 * _Time.w);
				float glitchTiming = sin(_Frequency * 100.0 * _Time.w);


				col = step(glitchTiming, col * glitch * -1.0);
                return col * glitch * 5.0;

				if (dissolve.b < _Cutoff) // 
					return col; //

				return col;
            }
            ENDCG
        }
    }
}
