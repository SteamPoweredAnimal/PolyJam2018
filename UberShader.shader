Shader "hidden/preview"
{
	Properties
	{
				Float_CC649D28("Transition", Float) = 0
				[NoScaleOffset] Texture_3C7F3E77("tile01_All", 2D) = "white" {}
				[NoScaleOffset] Texture_7893219E("basic_tile", 2D) = "white" {}
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_ReplaceColor_float(float3 In, float3 From, float3 To, float Range, out float3 Out)
			{
			    float3 col = In;
			    float Distance = distance(From, In);
			    if(Distance <= Range)
			        col = To;
			    Out = col;
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
				half4 uv0;
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_8146F638;
			float Float_CC649D28;
			UNITY_DECLARE_TEX2D(Texture_3C7F3E77);
			UNITY_DECLARE_TEX2D(Texture_7893219E);
			float4 _SampleTexture2D_A8C83A42_UV;
			float4 _SampleTexture2D_3EC6920C_UV;
			float4 _ReplaceColor_F6863576_In;
			float4 _ReplaceColor_F6863576_From;
			float4 _ReplaceColor_F6863576_To;
			float _ReplaceColor_F6863576_Range;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				half4 uv0 = IN.uv0;
				float _Property_F21D42C7_Out = Float_CC649D28;
				float4 _SampleTexture2D_A8C83A42_RGBA = UNITY_SAMPLE_TEX2D(Texture_3C7F3E77,uv0.xy);
				float _SampleTexture2D_A8C83A42_R = _SampleTexture2D_A8C83A42_RGBA.r;
				float _SampleTexture2D_A8C83A42_G = _SampleTexture2D_A8C83A42_RGBA.g;
				float _SampleTexture2D_A8C83A42_B = _SampleTexture2D_A8C83A42_RGBA.b;
				float _SampleTexture2D_A8C83A42_A = _SampleTexture2D_A8C83A42_RGBA.a;
				if (Float_8146F638 == 0) { surface.PreviewOutput = half4(_SampleTexture2D_A8C83A42_RGBA.x, _SampleTexture2D_A8C83A42_RGBA.y, _SampleTexture2D_A8C83A42_RGBA.z, 1.0); return surface; }
				float4 _SampleTexture2D_3EC6920C_RGBA = UNITY_SAMPLE_TEX2D(Texture_7893219E,uv0.xy);
				float _SampleTexture2D_3EC6920C_R = _SampleTexture2D_3EC6920C_RGBA.r;
				float _SampleTexture2D_3EC6920C_G = _SampleTexture2D_3EC6920C_RGBA.g;
				float _SampleTexture2D_3EC6920C_B = _SampleTexture2D_3EC6920C_RGBA.b;
				float _SampleTexture2D_3EC6920C_A = _SampleTexture2D_3EC6920C_RGBA.a;
				if (Float_8146F638 == 1) { surface.PreviewOutput = half4(_SampleTexture2D_3EC6920C_RGBA.x, _SampleTexture2D_3EC6920C_RGBA.y, _SampleTexture2D_3EC6920C_RGBA.z, 1.0); return surface; }
				float3 _ReplaceColor_F6863576_Out;
				Unity_ReplaceColor_float(_ReplaceColor_F6863576_In, _ReplaceColor_F6863576_From, _ReplaceColor_F6863576_To, _ReplaceColor_F6863576_Range, _ReplaceColor_F6863576_Out);
				if (Float_8146F638 == 2) { surface.PreviewOutput = half4(_ReplaceColor_F6863576_Out.x, _ReplaceColor_F6863576_Out.y, _ReplaceColor_F6863576_Out.z, 1.0); return surface; }
				return surface;
			}
	ENDCG
	
	SubShader
	{
	    Tags { "RenderType"="Opaque" }
	    LOD 100
	
	    Pass
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	
	        #include "UnityCG.cginc"
	
	        struct GraphVertexOutput
	        {
	            float4 position : POSITION;
	            half4 uv0 : TEXCOORD;
	
	        };
	
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            o.uv0 = v.texcoord0;
	
	            return o;
	        }
	
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            float4 uv0  = IN.uv0;
	
	
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            surfaceInput.uv0 = uv0;
	
	
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	
	        }
	        ENDCG
	    }
	}
}
