Shader "Custom/Fade" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_FadeDistance ("Fade Distance", Range (-80, 80)) = 50
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
		
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma surface surf Lambert finalcolor:mycolor vertex:myvert

		struct Input {
			float2 uv_MainTex;
			half alpha;
		};
		
		sampler2D _MainTex;
		float _FadeDistance;
		
		void myvert (inout appdata_full v, out Input data) {
			UNITY_INITIALIZE_OUTPUT(Input, data);
			half3 viewDist = length(_WorldSpaceCameraPos - mul ((half4x4)_Object2World, v.vertex));
			data.alpha = saturate ((viewDist - _FadeDistance) / 10);
		}
		
		void mycolor (Input IN, SurfaceOutput o, inout fixed4 color) {
			color.a = 1 - IN.alpha;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}