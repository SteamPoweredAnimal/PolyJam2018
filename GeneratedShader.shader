Shader "PBR Master"
{
	Properties
	{
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_522A15F1_Tex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline"}
		Tags
		{
			"RenderType"="Transparent"
			"Queue"="Transparent"
		}
		Pass
		{
			Tags{"LightMode" = "LightweightForward"}
			
					Blend SrcAlpha OneMinusSrcAlpha
					Cull Back
					ZTest LEqual
					ZWrite Off
			
			CGPROGRAM
			#pragma target 3.0
			
		    #pragma multi_compile _ _MAIN_LIGHT_COOKIE
		    #pragma multi_compile _MAIN_DIRECTIONAL_LIGHT _MAIN_SPOT_LIGHT
		    #pragma multi_compile _ _ADDITIONAL_LIGHTS
		    #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
		    #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON
		    #pragma multi_compile _ LIGHTMAP_ON
		    #pragma multi_compile _ DIRLIGHTMAP_COMBINED
		    #pragma multi_compile _ _HARD_SHADOWS _SOFT_SHADOWS _HARD_SHADOWS_CASCADES _SOFT_SHADOWS_CASCADES
		    #pragma multi_compile _ _VERTEX_LIGHTS
		    #pragma multi_compile_fog
		    #pragma multi_compile_instancing
		    #pragma vertex vert
			#pragma fragment frag
			
			#pragma glsl
			#pragma debug
			
						#define _AlphaOut 1
			#include "LightweightLighting.cginc"
								void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
							{
							    Out = A * B;
							}
							void Unity_Multiply_float(float A, float B, out float Out)
							{
							    Out = A * B;
							}
							void Unity_Sine_float(float In, out float Out)
							{
							    Out = sin(In);
							}
							void Unity_Add_float(float A, float B, out float Out)
							{
							    Out = A + B;
							}
							void Unity_Power_float(float A, float B, out float Out)
							{
							    Out = pow(A, B);
							}
							void Unity_Cosine_float(float In, out float Out)
							{
							    Out = cos(In);
							}
							void Unity_Clamp_float(float In, float Min, float Max, out float Out)
							{
							    Out = clamp(In, Min, Max);
							}
							void Unity_Lerp_float(float4 A, float4 B, float4 T, out float4 Out)
							{
							    Out = lerp(A, B, T);
							}
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord0 : TEXCOORD0;
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
							struct SurfaceInputs{
								half4 uv0;
							};
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
							};
							UNITY_DECLARE_TEX2D(_SampleTexture2D_522A15F1_Tex);
							float4 _SampleTexture2D_522A15F1_UV;
							float4 Color_66A2BAED;
							float4 _Multiply_EF228037_B;
							float4 Color_E0DB4C3B;
							float _Multiply_FD05A340_B;
							float _Add_767D71F7_B;
							float _Power_9BB21226_B;
							float _Multiply_8DD4714C_B;
							float _Add_C485FED0_B;
							float _Multiply_465726C7_B;
							float _Multiply_6924DB3A_B;
							float _Clamp_D94F8869_Min;
							float _Clamp_D94F8869_Max;
							float4 _Multiply_14091557_B;
							float4 _PBRMaster_595E6C50_Normal;
							float _PBRMaster_595E6C50_Metallic;
							float _PBRMaster_595E6C50_Smoothness;
							float _PBRMaster_595E6C50_Occlusion;
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								half4 uv0 = IN.uv0;
								float4 _SampleTexture2D_522A15F1_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_522A15F1_Tex,uv0.xy);
								float _SampleTexture2D_522A15F1_R = _SampleTexture2D_522A15F1_RGBA.r;
								float _SampleTexture2D_522A15F1_G = _SampleTexture2D_522A15F1_RGBA.g;
								float _SampleTexture2D_522A15F1_B = _SampleTexture2D_522A15F1_RGBA.b;
								float _SampleTexture2D_522A15F1_A = _SampleTexture2D_522A15F1_RGBA.a;
								float4 _Multiply_EF228037_Out;
								Unity_Multiply_float(Color_66A2BAED, _Multiply_EF228037_B, _Multiply_EF228037_Out);
								float4 _Multiply_EA310F84_Out;
								Unity_Multiply_float((_SampleTexture2D_522A15F1_B.xxxx), _Multiply_EF228037_Out, _Multiply_EA310F84_Out);
								float4 _Multiply_3DD5A703_Out;
								Unity_Multiply_float((_SampleTexture2D_522A15F1_R.xxxx), Color_E0DB4C3B, _Multiply_3DD5A703_Out);
								float _Multiply_FD05A340_Out;
								Unity_Multiply_float(_Time.y, _Multiply_FD05A340_B, _Multiply_FD05A340_Out);
								float _Sine_8DFBD739_Out;
								Unity_Sine_float(_Multiply_FD05A340_Out, _Sine_8DFBD739_Out);
								float _Add_767D71F7_Out;
								Unity_Add_float(_Sine_8DFBD739_Out, _Add_767D71F7_B, _Add_767D71F7_Out);
								float _Power_9BB21226_Out;
								Unity_Power_float(_Add_767D71F7_Out, _Power_9BB21226_B, _Power_9BB21226_Out);
								float _Multiply_8DD4714C_Out;
								Unity_Multiply_float(_Power_9BB21226_Out, _Multiply_8DD4714C_B, _Multiply_8DD4714C_Out);
								float _Add_C485FED0_Out;
								Unity_Add_float(_Multiply_8DD4714C_Out, _Add_C485FED0_B, _Add_C485FED0_Out);
								float _Multiply_465726C7_Out;
								Unity_Multiply_float(_Time.y, _Multiply_465726C7_B, _Multiply_465726C7_Out);
								float _Cosine_BA0CA376_Out;
								Unity_Cosine_float(_Multiply_465726C7_Out, _Cosine_BA0CA376_Out);
								float _Multiply_6924DB3A_Out;
								Unity_Multiply_float(_Cosine_BA0CA376_Out, _Multiply_6924DB3A_B, _Multiply_6924DB3A_Out);
								float _Add_F3B41850_Out;
								Unity_Add_float(_Add_C485FED0_Out, _Multiply_6924DB3A_Out, _Add_F3B41850_Out);
								float _Clamp_D94F8869_Out;
								Unity_Clamp_float(_Add_F3B41850_Out, _Clamp_D94F8869_Min, _Clamp_D94F8869_Max, _Clamp_D94F8869_Out);
								float4 _Lerp_B49E4547_Out;
								Unity_Lerp_float(_Multiply_EA310F84_Out, _Multiply_3DD5A703_Out, (_Clamp_D94F8869_Out.xxxx), _Lerp_B49E4547_Out);
								float4 _Multiply_E10EC811_Out;
								Unity_Multiply_float(_Lerp_B49E4547_Out, (_SampleTexture2D_522A15F1_A.xxxx), _Multiply_E10EC811_Out);
								float4 _Multiply_14091557_Out;
								Unity_Multiply_float(_Multiply_E10EC811_Out, _Multiply_14091557_B, _Multiply_14091557_Out);
								surface.Albedo = _Multiply_E10EC811_Out;
								surface.Normal = _PBRMaster_595E6C50_Normal;
								surface.Emission = _Multiply_14091557_Out;
								surface.Metallic = _PBRMaster_595E6C50_Metallic;
								surface.Smoothness = _PBRMaster_595E6C50_Smoothness;
								surface.Occlusion = _PBRMaster_595E6C50_Occlusion;
								surface.Alpha = _SampleTexture2D_522A15F1_R;
								return surface;
							}
			
			struct GraphVertexOutput
		    {
		        float4 position : SV_POSITION;
		#ifdef LIGHTMAP_ON
		        float4 lightmapUV : TEXCOORD0;
		#else
				float4 vertexSH : TEXCOORD0;
		#endif
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv0 : TEXCOORD8;
					half4 uv1 : TEXCOORD9;
				UNITY_VERTEX_OUTPUT_STEREO
		    };
			
		    GraphVertexOutput vert (GraphVertexInput v)
			{
			    v = PopulateVertexData(v);
				
				UNITY_SETUP_INSTANCE_ID(v);
		        GraphVertexOutput o = (GraphVertexOutput)0;
		        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		        			o.WorldSpaceNormal = mul(v.normal,(float3x3)unity_WorldToObject);
					o.WorldSpaceTangent = mul((float3x3)unity_ObjectToWorld,v.tangent);
					o.WorldSpaceBiTangent = normalize(cross(o.WorldSpaceNormal, o.WorldSpaceTangent.xyz) * v.tangent.w);
					o.WorldSpaceViewDirection = mul((float3x3)unity_ObjectToWorld,ObjSpaceViewDir(v.vertex));
					o.WorldSpacePosition = mul(unity_ObjectToWorld,v.vertex);
					o.uv0 = v.texcoord0;
					o.uv1 = v.texcoord1;
				float3 lwWNormal = normalize(UnityObjectToWorldNormal(v.normal));
				float4 lwWorldPos = mul(unity_ObjectToWorld, v.vertex);
				float4 clipPos = mul(UNITY_MATRIX_VP, lwWorldPos);
		#ifdef LIGHTMAP_ON
				o.lightmapUV.zw = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
		#else
				o.vertexSH = half4(EvaluateSHPerVertex(lwWNormal), 0.0);
		#endif
				o.fogFactorAndVertexLight.yzw = VertexLighting(lwWorldPos.xyz, lwWNormal);
				o.fogFactorAndVertexLight.x = ComputeFogFactor(clipPos.z);
		        o.position = clipPos;
				return o;
			}
			fixed4 frag (GraphVertexOutput IN) : SV_Target
		    {
		    				float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
					float3 WorldSpaceTangent = IN.WorldSpaceTangent;
					float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
					float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
					float3 WorldSpacePosition = IN.WorldSpacePosition;
					float4 uv0  = IN.uv0;
					float4 uv1  = IN.uv1;
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.uv0 = uv0;
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 0;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
		#if defined(UNITY_COLORSPACE_GAMMA) 
		       	Albedo = Albedo * Albedo;
		       	Emission = Emission * Emission;
		#endif
		#if _NORMALMAP
		    half3 normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
		#else
		    half3 normalWS = normalize(WorldSpaceNormal);
		#endif
		#if LIGHTMAP_ON
			half3 indirectDiffuse = SampleLightmap(IN.lightmapUV.zw, normalWS);
		#else
			half3 indirectDiffuse = EvaluateSHPerPixel(normalWS, IN.vertexSH);
		#endif
			half4 color = LightweightFragmentPBR(
					WorldSpacePosition,
					normalWS,
					WorldSpaceViewDirection,
					indirectDiffuse,
					IN.fogFactorAndVertexLight.yzw, 
					Albedo,
					Metallic,
					Specular,
					Smoothness,
					Occlusion,
					Emission,
					Alpha);
			// Computes fog factor per-vertex
		    ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);
		#if _AlphaOut
				color.a = Alpha;
		#else
				color.a = 1;
		#endif
		#if _AlphaClip
				clip(Alpha - 0.01);
		#endif
				return color;
		    }
			ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "ShadowCaster"}
		    ZWrite On ZTest LEqual
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex ShadowPassVertex
		    #pragma fragment ShadowPassFragment
		    #include "UnityCG.cginc"
		    #include "LightweightPassShadow.cginc"
		    ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "DepthOnly"}
		    ZWrite On
		    ColorMask 0
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex vert
		    #pragma fragment frag
		    #include "UnityCG.cginc"
		    float4 vert(float4 pos : POSITION) : SV_POSITION
		    {
		        return UnityObjectToClipPos(pos);
		    }
		    half4 frag() : SV_TARGET
		    {
		        return 0;
		    }
		    ENDCG
		}
	}
}
