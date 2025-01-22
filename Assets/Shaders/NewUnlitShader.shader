Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
        _Speed ("Speed", Float) = 1
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "RenderPipeline" = "UniversalPipeline"
        }
        LOD 100

        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 positionOS : POSITION;
            };

            struct v2f
            {
                float4 positionCS : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _BaseColor;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                return o;
            }

            float4 frag (v2f i) : SV_TARGET
            {
                return _BaseColor; //* _Time.y * _Speed;
            }
            
            ENDHLSL
        }
    }
}
