﻿Shader "Custom/Crt pixel"
{
	Properties
	{
		_MainTex("Texture Pixel", 2D) = "white" {}
		_ScansColor("Color Scans", COLOR) = (1,1,1,1)
		_Tiles("Tiles value", Range(1, 10000)) = 500
		_VertsColor("Verts fill color", Range(0, 1)) = 0
		_VertsColor2("Verts fill color 2", Range(0, 1)) = 0
		_Contrast("Contrast", Range(-20, 20)) = 0
		_Br("Brightness", Range(-200, 200)) = 0
		_Density("Density", Range(0, 30)) = 0

		_Strength("Strenght curve", Range(-0.035, 30)) = 0.0
		_DisplacementTex("Displace Text", 2D) = "white" {}
		_Distort("Distortion", Range(-0.1, 0.1)) = 0.0
		_OnOff("OnOff", Range(0.0, 1000.0)) = 1.0
		_ScanDensity("Scan density", Range(0.0, 1.0)) = 1.0
		_ScanThikness("Scan thick", Range(0.0, 500.0)) = 100.0
		_ScanPoint("Scan point", Range(-200, 2000)) = 0.0


			// Ripple

		_MainTex("Texture", 2D) = "white" {}
		_CenterX("Center X", float) = 300
		_CenterY("Center Y", float) = 250
		_Amount("Amount", float) = 25
		_Radius("Radius", float) = 25
		_WaveSpeed("Wave Speed", range(.50, 50)) = 20
		_WaveAmount("Wave Amount", range(0, 20)) = 10

	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 scr_pos : TEXCOORD1;
					float4 vertex : SV_POSITION;
				};

				float _Tiles;
				sampler2D _MainTex;
				float _VertsColor;
				float _VertsColor2;
				float _Contrast;
				float _Br;
				float4 _ScansColor;
				float _Density;
				float _Strength;
				sampler2D _DisplacementTex;
				float _Distort;
				float _OnOff;
				float _ScanDensity;
				float _ScanThikness;
				float _ScanPoint;

				//Ripple

				float _CenterX;
				float _CenterY;
				float _Amount;
				float _WaveSpeed;
				float _WaveAmount;
				float _Radius;


				v2f vert(appdata v)
				{
					v2f o;

					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					o.scr_pos = ComputeScreenPos(o.vertex);
					return o;
				}


				float4 frag(v2f i) : SV_Target
				{
					///Curvature
					half2 n = tex2D(_DisplacementTex, i.uv);
					half2 d = n * 2 - 1;
					i.uv += d * _Strength;
					i.uv = saturate(i.uv);
					///

					//Distort image on y axis
					i.uv.y += _Distort;


					// RIPPLE -----------------------------------

					/*//Sawtooth function to pulse from centre.
						float offset = (_Time.y- floor(_Time.y))/_Time.y;
						float CurrentTime = (_Time.y)*(offset);    
    
						float3 WaveParams = float3(10.0, 0.8, 0.1 ); 
    
						float ratio = (_ScreenParams.y/_ScreenParams.x);
    
						//Use this if you want to place the centre with the mouse instead
						//vec2 WaveCentre = vec2( iMouse.xy / iResolution.xy );
       
						fixed2 WaveCentre = fixed2(_CenterX / _ScreenParams.x, _CenterY / _ScreenParams.y);
						//fixed2 WaveCentre = fixed2(0.5, 0.5);
						//WaveCentre.y *= ratio; 
   
						float2 texCoord = i.uv.xy / _ScreenParams.xy;      
						texCoord.y *= ratio;    
						float Dist = distance(texCoord, WaveCentre);
    
	
						fixed4 color = tex2D(_MainTex, i.uv);
    
					//Only distort the pixels within the parameter distance from the centre
					if ((Dist <= ((CurrentTime) + (WaveParams.z))) && 
						(Dist >= ((CurrentTime) - (WaveParams.z)))) 
						{
							//The pixel offset distance based on the input parameters
							float Diff = (Dist - CurrentTime); 
							float ScaleDiff = (1.0 - pow(abs(Diff * WaveParams.x), WaveParams.y)); 
							float DiffTime = (Diff  * ScaleDiff);
        
							//The direction of the distortion
							float2 DiffTexCoord = normalize(texCoord - WaveCentre);         
        
							//Perform the distortion and reduce the effect over time
							texCoord += ((DiffTexCoord * DiffTime) / (CurrentTime * Dist * 40.0));
							color = tex2D(_MainTex, i.uv);
        
							//Blow out the color and reduce the effect over time
							color += (color * ScaleDiff) / (CurrentTime * Dist * 40.0);
						} */


					fixed2 center = fixed2(_CenterX / _ScreenParams.x, _CenterY / _ScreenParams.y);
					fixed time = _Time.y * _WaveSpeed;
					fixed amt = _Amount / 1000;

					fixed2 uv = center.xy - i.uv;
					uv.x *= (_ScreenParams.x  / _ScreenParams.y) ;


					fixed dist = sqrt(dot(uv, uv)) + _Radius; // test

					fixed ang = dist * _WaveAmount - time;
					uv = i.uv + normalize(uv) * sin(ang) * amt;

					float4 color = tex2D(_MainTex, uv);



					// RIPPLE -----------------------------------

					//Vertical lines
					float2 ps = i.scr_pos.xy * _ScreenParams.xy / i.scr_pos.w;
					int pp = (int)ps.x % _Density;
					float4 outcolor = float4(0, 0, 0, 1);
					float4 muls = float4(0, 0, 0, 1);
					if (pp < _Density / 3) {
						outcolor.r = color.r;
						outcolor.g = color.g * _VertsColor;
						outcolor.b = color.b * _VertsColor2;
					}
					else if (pp < (2 * _Density) / 3) {
						outcolor.g = color.g;
						outcolor.r = color.r * _VertsColor;
						outcolor.b = color.b * _VertsColor2;
					}
					else {
						outcolor.b = color.b;
						outcolor.r = color.r * _VertsColor;
						outcolor.g = color.g * _VertsColor2;
					}

					//Horizontal lines
					if ((int)ps.y % _Density == 0) outcolor *= float4(_ScansColor.r, _ScansColor.g, _ScansColor.b, 1);

					//Color correciton
					outcolor += (_Br / 255);
					outcolor = outcolor - _Contrast * (outcolor - 1.0) * outcolor * (outcolor - 0.5);

					//Scan lines
					if ((i.scr_pos.y * _ScreenParams.y) >= _ScanPoint && (i.scr_pos.y * _ScreenParams.y) < _ScanPoint + _ScanThikness)
					{
						outcolor *= _ScanDensity;
					}

					return outcolor;
				}
				ENDCG
			}
		}
}