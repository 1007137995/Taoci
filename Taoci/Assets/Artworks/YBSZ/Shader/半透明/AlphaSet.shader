Shader "Snoopy/AlphaBase"
{
	Properties
	{
		_MainTex("Particle Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
	
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
 
		//这里加一个pass为了不会穿透叠自己的颜色，可以取消这个pass看看效果
		Pass
		{
			ZWrite On
			ColorMask 0
		}
 
		CGPROGRAM
		//使用alpha通道
		#pragma surface surf Lambert alpha
 
		struct Input
		{
			float2 uv_MainTex;
		};
 
		sampler2D _MainTex;
		fixed4 _Color;
 
		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 col = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = col.rgb * _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	Fallback "VertexLit"
}
