Shader "Custom/Explosion2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DissolveTex ("DissolveTex", 2D) = "white" {}
		_Cutoff("Cutoff", Range(-0.1, 1)) = 0
    }
    SubShader
    {
		Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
		Cull Off
		Blend One OneMinusSrcAlpha
		LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"


            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

			sampler2D _DissolveTex;
            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _Cutoff;

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 dissolve = tex2D(_DissolveTex, i.uv);

				col.rgb *= col.a;

				if (dissolve.b > _Cutoff) // 
				{
					return col = 0;
				}
				else
				{
					return col;
				}


            }
            ENDCG
        }
    }
}
