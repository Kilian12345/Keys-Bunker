// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Explo2D"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Gradient ("_Gradient", 2D) = "white" {}
        _Value ("_Value", Float) = 1.0

        _Color ("_Color", Color) = (.34, .85, .92, 1) // color
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _Gradient;
            float _Value;

            fixed4 _Color;

            v2f vert(appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                float grad = tex2D(_Gradient, i.uv).r;


                //col.a = ceil(col.a);
                //col.rgb *= col.a;

                col.a *= step(_Value, grad);
                return col * _Color;
            }
            ENDCG
        }
    }
}
