/// <summary> Shader to slowly change an objects alpha values depending 
/// on the distance of the object to the camera. </summary>

Shader "Custom/LightClip" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader 
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert finalcolor:finalfade vertex:fade
		
		sampler2D _MainTex;
		
		struct Input 
		{
			float2 uv_MainTex;
			half alpha;
		};
		
		void fade (inout appdata_full v, out Input data)
		{
			// This should get this objects world position
			float3 _WorldSpacePos = mul( _Object2World, v.vertex);
			data.alpha = 1 * (_WorldSpacePos.z);
		}
		
		void finalfade (Input IN, SurfaceOutput o, inout fixed4 color) 
		{
			// This should take the world position above and change the alpha
			o.Alpha = lerp(1f, color.a, _Time);
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{
			// Nothing should really change here
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}