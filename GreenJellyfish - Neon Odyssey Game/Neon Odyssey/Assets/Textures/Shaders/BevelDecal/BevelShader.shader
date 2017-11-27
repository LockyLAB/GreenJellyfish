// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-9510-RGB,spec-7099-OUT,gloss-1148-OUT,normal-4333-RGB,emission-930-OUT;n:type:ShaderForge.SFN_ComponentMask,id:596,x:31713,y:32669,varname:node_596,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5470-B;n:type:ShaderForge.SFN_Multiply,id:930,x:32186,y:32812,varname:node_930,prsc:2|A-596-OUT,B-3410-OUT;n:type:ShaderForge.SFN_Tex2d,id:2969,x:31732,y:33420,ptovrint:False,ptlb:node_8275_copy,ptin:_node_8275_copy,varname:_node_8275_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3f778c1d98df92f449b5d62570be310c,ntxv:0,isnm:False|UVIN-5099-UVOUT;n:type:ShaderForge.SFN_Slider,id:1501,x:31219,y:33760,ptovrint:False,ptlb:node_364,ptin:_node_364,varname:node_364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.381386,max:2;n:type:ShaderForge.SFN_RemapRange,id:501,x:31762,y:33751,varname:node_501,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-6013-OUT;n:type:ShaderForge.SFN_Divide,id:4094,x:31946,y:33730,varname:node_4094,prsc:2|A-6737-TSL,B-501-OUT;n:type:ShaderForge.SFN_TexCoord,id:3239,x:31374,y:33369,varname:node_3239,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:5099,x:31543,y:33381,varname:node_5099,prsc:2,spu:0,spv:1|UVIN-3239-UVOUT,DIST-4094-OUT;n:type:ShaderForge.SFN_Time,id:6737,x:31185,y:33537,varname:node_6737,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:6013,x:31580,y:33768,varname:node_6013,prsc:2|IN-1501-OUT;n:type:ShaderForge.SFN_RemapRange,id:6764,x:31926,y:33420,varname:node_6764,prsc:2,frmn:0,frmx:1,tomn:0,tomx:2.2|IN-2969-RGB;n:type:ShaderForge.SFN_Tex2d,id:94,x:31268,y:32831,ptovrint:False,ptlb:node_4106,ptin:_node_4106,varname:node_4106,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:79aa060182c8fb842af5637a55ca9374,ntxv:0,isnm:False|UVIN-3864-UVOUT;n:type:ShaderForge.SFN_Slider,id:8884,x:30751,y:33184,ptovrint:False,ptlb:node_364_copy,ptin:_node_364_copy,varname:_node_364_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5294831,max:1;n:type:ShaderForge.SFN_RemapRange,id:6435,x:31293,y:33171,varname:node_6435,prsc:2,frmn:0,frmx:1,tomn:0,tomx:3|IN-7849-OUT;n:type:ShaderForge.SFN_Divide,id:2618,x:31477,y:33150,varname:node_2618,prsc:2|A-9875-TSL,B-6435-OUT;n:type:ShaderForge.SFN_TexCoord,id:2664,x:30905,y:32789,varname:node_2664,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3864,x:31074,y:32801,varname:node_3864,prsc:2,spu:1,spv:1|UVIN-2664-UVOUT,DIST-2618-OUT;n:type:ShaderForge.SFN_Time,id:9875,x:30716,y:32957,varname:node_9875,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:9907,x:31470,y:32858,varname:node_9907,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-94-G;n:type:ShaderForge.SFN_Multiply,id:4297,x:31867,y:32929,varname:node_4297,prsc:2|A-9907-OUT,B-6764-OUT;n:type:ShaderForge.SFN_OneMinus,id:7849,x:31103,y:33182,varname:node_7849,prsc:2|IN-8884-OUT;n:type:ShaderForge.SFN_RemapRange,id:3148,x:31618,y:32868,varname:node_3148,prsc:2,frmn:0,frmx:1,tomn:-0.9,tomx:1.2|IN-9907-OUT;n:type:ShaderForge.SFN_Tex2d,id:5470,x:31489,y:32651,ptovrint:False,ptlb:node_5470,ptin:_node_5470,varname:node_5470,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:79aa060182c8fb842af5637a55ca9374,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:7099,x:32497,y:32894,varname:node_7099,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:1148,x:32497,y:32954,varname:node_1148,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:9510,x:32155,y:32645,ptovrint:False,ptlb:node_9510,ptin:_node_9510,varname:node_9510,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ddb46698e7c3e0244b639630c9a1b9cb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRange,id:3410,x:32016,y:32929,varname:node_3410,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1.6|IN-4297-OUT;n:type:ShaderForge.SFN_Tex2d,id:4333,x:32473,y:33069,ptovrint:False,ptlb:node_4333,ptin:_node_4333,varname:node_4333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:925281a5cd61be54590db57316e2fcfc,ntxv:3,isnm:True;proporder:2969-1501-94-8884-5470-9510-4333;pass:END;sub:END;*/

Shader "Shader Forge/BevelShader" {
    Properties {
        _node_8275_copy ("node_8275_copy", 2D) = "white" {}
        _node_364 ("node_364", Range(0, 2)) = 1.381386
        _node_4106 ("node_4106", 2D) = "white" {}
        _node_364_copy ("node_364_copy", Range(0, 1)) = 0.5294831
        _node_5470 ("node_5470", 2D) = "white" {}
        _node_9510 ("node_9510", 2D) = "white" {}
        _node_4333 ("node_4333", 2D) = "bump" {}
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
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            uniform sampler2D _node_5470; uniform float4 _node_5470_ST;
            uniform sampler2D _node_9510; uniform float4 _node_9510_ST;
            uniform sampler2D _node_4333; uniform float4 _node_4333_ST;
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
                float3 _node_4333_var = UnpackNormal(tex2D(_node_4333,TRANSFORM_TEX(i.uv0, _node_4333)));
                float3 normalLocal = _node_4333_var.rgb;
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
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
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
                float3 specularColor = 0.5;
                float specularMonochrome;
                float4 _node_9510_var = tex2D(_node_9510,TRANSFORM_TEX(i.uv0, _node_9510));
                float3 diffuseColor = _node_9510_var.rgb; // Need this for specular when using metallic
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
                float4 _node_5470_var = tex2D(_node_5470,TRANSFORM_TEX(i.uv0, _node_5470));
                float4 node_9875 = _Time;
                float2 node_3864 = (i.uv0+(node_9875.r/((1.0 - _node_364_copy)*3.0+0.0))*float2(1,1));
                float4 _node_4106_var = tex2D(_node_4106,TRANSFORM_TEX(node_3864, _node_4106));
                float node_9907 = _node_4106_var.g.r;
                float4 node_6737 = _Time;
                float2 node_5099 = (i.uv0+(node_6737.r/((1.0 - _node_364)*9.0+1.0))*float2(0,1));
                float4 _node_8275_copy_var = tex2D(_node_8275_copy,TRANSFORM_TEX(node_5099, _node_8275_copy));
                float3 node_6764 = (_node_8275_copy_var.rgb*2.2+0.0);
                float3 emissive = (_node_5470_var.b.r*((node_9907*node_6764)*1.6+0.0));
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
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            uniform sampler2D _node_5470; uniform float4 _node_5470_ST;
            uniform sampler2D _node_9510; uniform float4 _node_9510_ST;
            uniform sampler2D _node_4333; uniform float4 _node_4333_ST;
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
                float3 _node_4333_var = UnpackNormal(tex2D(_node_4333,TRANSFORM_TEX(i.uv0, _node_4333)));
                float3 normalLocal = _node_4333_var.rgb;
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
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.5;
                float specularMonochrome;
                float4 _node_9510_var = tex2D(_node_9510,TRANSFORM_TEX(i.uv0, _node_9510));
                float3 diffuseColor = _node_9510_var.rgb; // Need this for specular when using metallic
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
            uniform sampler2D _node_8275_copy; uniform float4 _node_8275_copy_ST;
            uniform float _node_364;
            uniform sampler2D _node_4106; uniform float4 _node_4106_ST;
            uniform float _node_364_copy;
            uniform sampler2D _node_5470; uniform float4 _node_5470_ST;
            uniform sampler2D _node_9510; uniform float4 _node_9510_ST;
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
                
                float4 _node_5470_var = tex2D(_node_5470,TRANSFORM_TEX(i.uv0, _node_5470));
                float4 node_9875 = _Time;
                float2 node_3864 = (i.uv0+(node_9875.r/((1.0 - _node_364_copy)*3.0+0.0))*float2(1,1));
                float4 _node_4106_var = tex2D(_node_4106,TRANSFORM_TEX(node_3864, _node_4106));
                float node_9907 = _node_4106_var.g.r;
                float4 node_6737 = _Time;
                float2 node_5099 = (i.uv0+(node_6737.r/((1.0 - _node_364)*9.0+1.0))*float2(0,1));
                float4 _node_8275_copy_var = tex2D(_node_8275_copy,TRANSFORM_TEX(node_5099, _node_8275_copy));
                float3 node_6764 = (_node_8275_copy_var.rgb*2.2+0.0);
                o.Emission = (_node_5470_var.b.r*((node_9907*node_6764)*1.6+0.0));
                
                float4 _node_9510_var = tex2D(_node_9510,TRANSFORM_TEX(i.uv0, _node_9510));
                float3 diffColor = _node_9510_var.rgb;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.5, specColor, specularMonochrome );
                float roughness = 1.0 - 0.5;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
