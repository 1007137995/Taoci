Shader "VrorangeShaders/Mirror Reflection with Shadow" {
Properties {
   _Color ("Main Color", Color) = (1,1,1,1)
   _ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
   _MainTex ("Base (RGB) RefStrength (A)", 2D) = "white" {}
   _ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }

}

SubShader {
	LOD 200
	Tags { "RenderType"="Opaque" }
	
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _ReflectionTex;

float4 _Color;
float4 _ReflectColor;

struct Input {
	float2 uv_MainTex;
	float4 screenPos;
};

void surf (Input IN, inout SurfaceOutput o) {
	half4 tex = tex2D(_MainTex, IN.uv_MainTex);
	half4 c = tex * _Color;
	o.Albedo = c.rgb;
	
	float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
	half4 reflcol = tex2D(_ReflectionTex,screenUV);
	reflcol *= tex.a;
	o.Emission = reflcol.rgb * _ReflectColor.rgb;
	o.Alpha = reflcol.a * _ReflectColor.a;
}
ENDCG
}
	
FallBack "Reflective/VertexLit"
} 