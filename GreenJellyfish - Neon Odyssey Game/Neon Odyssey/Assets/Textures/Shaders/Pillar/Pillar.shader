// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-4596-RGB,spec-8915-B,gloss-8915-A,normal-5964-RGB,emission-9398-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32407,y:32978,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:690b099fd97334c4682fede9a897b714,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4596,x:32400,y:32359,ptovrint:False,ptlb:node_4596,ptin:_node_4596,varname:node_4596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2b232c8784a1ca940987d8e606ec9be2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8915,x:32522,y:33169,ptovrint:False,ptlb:node_8915,ptin:_node_8915,varname:node_8915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:75c5a8f28dde4cc4b8e2ef71a1e9c1e4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8275,x:31453,y:32587,ptovrint:False,ptlb:node_8275,ptin:_node_8275,varname:node_8275,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3f778c1d98df92f449b5d62570be310c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:252,x:31649,y:32605,varname:node_252,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8275-A;n:type:ShaderForge.SFN_Multiply,id:5773,x:32122,y:32748,varname:node_5773,prsc:2|A-252-OUT,B-3561-OUT;n:type:ShaderForge.SFN_Tex2d,id:8049,x:31668,y:33356,ptovrint:False,ptlb:node_8275_copy,ptin:_node_8275_copy,varname:_node_8275_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3f778c1d98df92f449b5d62570be310c,ntxv:0,isnm:False|UVIN-7472-UVOUT;n:type:ShaderForge.SFN_Slider,id:364,x:31155,y:33696,ptovrint:False,ptlb:node_364,ptin:_node_364,varname:node_364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.381386,max:2;n:type:ShaderForge.SFN_RemapRange,id:8629,x:31698,y:33687,varname:node_8629,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-3921-OUT;n:type:ShaderForge.SFN_Divide,id:8640,x:31882,y:33666,varname:node_8640,prsc:2|A-6520-TSL,B-8629-OUT;n:type:ShaderForge.SFN_TexCoord,id:7836,x:31310,y:33305,varname:node_7836,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7472,x:31479,y:33317,varname:node_7472,prsc:2,spu:0,spv:1|UVIN-7836-UVOUT,DIST-8640-OUT;n:type:ShaderForge.SFN_Time,id:6520,x:31121,y:33473,varname:node_6520,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:3921,x:31516,y:33704,varname:node_3921,prsc:2|IN-364-OUT;n:type:ShaderForge.SFN_RemapRange,id:4275,x:31862,y:33356,varname:node_4275,prsc:2,frmn:0,frmx:1,tomn:0,tomx:2.5|IN-8049-RGB;n:type:ShaderForge.SFN_Tex2d,id:4106,x:31204,y:32767,ptovrint:False,ptlb:node_4106,ptin:_node_4106,varname:node_4106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fb45fe0d101daa34e9eda1021f20509f,ntxv:0,isnm:False|UVIN-841-UVOUT;n:type:ShaderForge.SFN_Slider,id:3067,x:30687,y:33120,ptovrint:False,ptlb:node_364_copy,ptin:_node_364_copy,varname:_node_364_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5294831,max:1;n:type:ShaderForge.SFN_RemapRange,id:8787,x:31229,y:33107,varname:node_8787,prsc:2,frmn:0,frmx:1,tomn:0,tomx:3|IN-9372-OUT;n:type:ShaderForge.SFN_Divide,id:1786,x:31413,y:33086,varname:node_1786,prsc:2|A-8218-TSL,B-8787-OUT;n:type:ShaderForge.SFN_TexCoord,id:4253,x:30841,y:32725,varname:node_4253,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:841,x:31010,y:32737,varname:node_841,prsc:2,spu:0,spv:1|UVIN-4253-UVOUT,DIST-1786-OUT;n:type:ShaderForge.SFN_Time,id:8218,x:30652,y:32893,varname:node_8218,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:3361,x:31406,y:32794,varname:node_3361,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-4106-RGB;n:type:ShaderForge.SFN_Multiply,id:3561,x:31803,y:32865,varname:node_3561,prsc:2|A-8114-OUT,B-4275-OUT;n:type:ShaderForge.SFN_OneMinus,id:9372,x:31039,y:33118,varname:node_9372,prsc:2|IN-3067-OUT;n:type:ShaderForge.SFN_RemapRange,id:8114,x:31554,y:32804,varname:node_8114,prsc:2,frmn:0,frmx:1,tomn:-0.7,tomx:1.2|IN-3361-OUT;n:type:ShaderForge.SFN_RemapRange,id:9398,x:32312,y:32748,varname:node_9398,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1.8|IN-5773-OUT;proporder:5964-4596-8915-8275-8049-364-4106-3067;pass:END;sub:END;*/

Shader "Shader Forge/Pillar" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _node_4596 ("node_4596", 2D) = "white" {}
        _node_8915 ("node_8915", 2D) = "white" {}
        _node_8275 ("node_8275", 2D) = "white" {}
        _node_8275_copy ("node_8275_copy", 2D) = "white" {}
        _node_364 ("node_364", Range(0, 2)) = 1.381386
        _node_4106 ("node_4106", 2D) = "white" {}
        _node_364_copy ("node_364_copy", Range(0, 1)) = 0.5294831
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _node_4596; uniform float4 _node_4596_ST;
            uniform sampler2D _node_8915; uniform float4 _node_8915_ST;
            uniform sampler2D _node_8275; uniform float4 _node_8275_ST;
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _node_8915_var = tex2D(_node_8915,TRANSFORM_TEX(i.uv0, _node_8915));
                float gloss = _node_8915_var.a;
                float perceptualRoughness = 1.0 - _node_8915_var.a;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _node_8915_var.b;
                float specularMonochrome;
                float4 _node_4596_var = tex2D(_node_4596,TRANSFORM_TEX(i.uv0, _node_4596));
                float3 diffuseColor = _node_4596_var.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _node_8275_var = tex2D(_node_8275,TRANSFORM_TEX(i.uv0, _node_8275));
                float4 node_8218 = _Time;
                float2 node_841 = (i.uv0+(node_8218.r/((1.0 - _node_364_copy)*3.0+0.0))*float2(0,1));
                float4 _node_4106_var = tex2D(_node_4106,TRANSFORM_TEX(node_841, _node_4106));
                float4 node_6520 = _Time;
                float2 node_7472 = (i.uv0+(node_6520.r/((1.0 - _node_364)*9.0+1.0))*float2(0,1));
                float4 _node_8275_copy_var = tex2D(_node_8275_copy,TRANSFORM_TEX(node_7472, _node_8275_copy));
                float3 emissive = ((_node_8275_var.a.r*((_node_4106_var.rgb.r*1.9+-0.7)*(_node_8275_copy_var.rgb*2.5+0.0)))*1.8+0.0);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _node_4596; uniform float4 _node_4596_ST;
            uniform sampler2D _node_8915; uniform float4 _node_8915_ST;
            uniform sampler2D _node_8275; uniform float4 _node_8275_ST;
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _node_8915_var = tex2D(_node_8915,TRANSFORM_TEX(i.uv0, _node_8915));
                float gloss = _node_8915_var.a;
                float perceptualRoughness = 1.0 - _node_8915_var.a;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _node_8915_var.b;
                float specularMonochrome;
                float4 _node_4596_var = tex2D(_node_4596,TRANSFORM_TEX(i.uv0, _node_4596));
                float3 diffuseColor = _node_4596_var.rgb; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4596; uniform float4 _node_4596_ST;
            uniform sampler2D _node_8915; uniform float4 _node_8915_ST;
            uniform sampler2D _node_8275; uniform float4 _node_8275_ST;
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _node_8275_var = tex2D(_node_8275,TRANSFORM_TEX(i.uv0, _node_8275));
                float4 node_8218 = _Time;
                float2 node_841 = (i.uv0+(node_8218.r/((1.0 - _node_364_copy)*3.0+0.0))*float2(0,1));
                float4 _node_4106_var = tex2D(_node_4106,TRANSFORM_TEX(node_841, _node_4106));
                float4 node_6520 = _Time;
                float2 node_7472 = (i.uv0+(node_6520.r/((1.0 - _node_364)*9.0+1.0))*float2(0,1));
                float4 _node_8275_copy_var = tex2D(_node_8275_copy,TRANSFORM_TEX(node_7472, _node_8275_copy));
                o.Emission = ((_node_8275_var.a.r*((_node_4106_var.rgb.r*1.9+-0.7)*(_node_8275_copy_var.rgb*2.5+0.0)))*1.8+0.0);
                
                float4 _node_4596_var = tex2D(_node_4596,TRANSFORM_TEX(i.uv0, _node_4596));
                float3 diffColor = _node_4596_var.rgb;
                float specularMonochrome;
                float3 specColor;
                float4 _node_8915_var = tex2D(_node_8915,TRANSFORM_TEX(i.uv0, _node_8915));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _node_8915_var.b, specColor, specularMonochrome );
                float roughness = 1.0 - _node_8915_var.a;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
