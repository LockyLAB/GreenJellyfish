// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-5751-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB,emission-540-OUT,alpha-5368-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32691,y:33471,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32534,y:33273,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32534,y:33375,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:7677,x:31207,y:33214,ptovrint:False,ptlb:Emissive Pattern,ptin:_EmissivePattern,varname:node_7677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c80433b28df813a489a103bcab799c85,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:8564,x:31435,y:33133,varname:node_8564,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7677-R;n:type:ShaderForge.SFN_Multiply,id:3995,x:31984,y:33260,varname:node_3995,prsc:2|A-8564-OUT,B-2450-OUT;n:type:ShaderForge.SFN_TexCoord,id:2112,x:30942,y:33458,varname:node_2112,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1041,x:31136,y:33458,varname:node_1041,prsc:2,spu:-1,spv:-1|UVIN-2112-UVOUT,DIST-130-OUT;n:type:ShaderForge.SFN_Time,id:8488,x:30706,y:33663,varname:node_8488,prsc:2;n:type:ShaderForge.SFN_Slider,id:5597,x:30549,y:33905,ptovrint:False,ptlb:Glow Speed,ptin:_GlowSpeed,varname:node_5597,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.0489468,max:1;n:type:ShaderForge.SFN_OneMinus,id:3997,x:30906,y:33904,varname:node_3997,prsc:2|IN-5597-OUT;n:type:ShaderForge.SFN_RemapRange,id:3723,x:31078,y:33904,varname:node_3723,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-3997-OUT;n:type:ShaderForge.SFN_Divide,id:130,x:31277,y:33872,varname:node_130,prsc:2|A-8488-T,B-3723-OUT;n:type:ShaderForge.SFN_Tex2d,id:3275,x:31340,y:33458,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:_node_7677_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:19099d4786ead2146a0ce88af33054b1,ntxv:0,isnm:False|UVIN-1041-UVOUT;n:type:ShaderForge.SFN_Color,id:4041,x:31340,y:33657,ptovrint:False,ptlb:Glow Colour,ptin:_GlowColour,varname:node_4041,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1375432,c2:0.7262916,c3:0.7794118,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:5368,x:31901,y:33595,varname:node_5368,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7677-G;n:type:ShaderForge.SFN_RemapRange,id:215,x:31496,y:33458,varname:node_215,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:0.5|IN-3275-G;n:type:ShaderForge.SFN_Add,id:574,x:31666,y:33643,varname:node_574,prsc:2|A-215-OUT,B-4041-RGB;n:type:ShaderForge.SFN_RemapRange,id:2450,x:31826,y:33396,varname:node_2450,prsc:2,frmn:0,frmx:1,tomn:-0.4,tomx:0.9|IN-574-OUT;n:type:ShaderForge.SFN_Tex2d,id:7420,x:31544,y:33017,ptovrint:False,ptlb:node_7420,ptin:_node_7420,varname:node_7420,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0a7ec0de640fbb4428a3881f0a10540f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:4513,x:31758,y:33017,varname:node_4513,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7420-RGB;n:type:ShaderForge.SFN_ComponentMask,id:8665,x:31444,y:32585,varname:node_8665,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6521-B;n:type:ShaderForge.SFN_TexCoord,id:7465,x:30601,y:32703,varname:node_7465,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7730,x:30795,y:32703,varname:node_7730,prsc:2,spu:-1,spv:-1|UVIN-7465-UVOUT,DIST-1605-OUT;n:type:ShaderForge.SFN_Time,id:8896,x:30365,y:32908,varname:node_8896,prsc:2;n:type:ShaderForge.SFN_Slider,id:7029,x:30229,y:33150,ptovrint:False,ptlb:Glow Speed_copy,ptin:_GlowSpeed_copy,varname:_GlowSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.476329,max:1;n:type:ShaderForge.SFN_OneMinus,id:1713,x:30565,y:33149,varname:node_1713,prsc:2|IN-7029-OUT;n:type:ShaderForge.SFN_RemapRange,id:5437,x:30737,y:33149,varname:node_5437,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-1713-OUT;n:type:ShaderForge.SFN_Divide,id:1605,x:30936,y:33117,varname:node_1605,prsc:2|A-8896-T,B-5437-OUT;n:type:ShaderForge.SFN_Tex2d,id:7973,x:30999,y:32703,ptovrint:False,ptlb:Glow_copy,ptin:_Glow_copy,varname:_Glow_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:19099d4786ead2146a0ce88af33054b1,ntxv:0,isnm:False|UVIN-7730-UVOUT;n:type:ShaderForge.SFN_Color,id:8433,x:30999,y:32902,ptovrint:False,ptlb:Glow Colour_copy,ptin:_GlowColour_copy,varname:_GlowColour_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1375432,c2:0.7262916,c3:0.7794118,c4:1;n:type:ShaderForge.SFN_RemapRange,id:4088,x:31155,y:32703,varname:node_4088,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:0.5|IN-7973-G;n:type:ShaderForge.SFN_Add,id:1505,x:31279,y:32913,varname:node_1505,prsc:2|A-4088-OUT,B-8433-RGB;n:type:ShaderForge.SFN_Multiply,id:5751,x:31597,y:32787,varname:node_5751,prsc:2|A-8665-OUT,B-1505-OUT;n:type:ShaderForge.SFN_Multiply,id:540,x:32153,y:33140,varname:node_540,prsc:2|A-6457-OUT,B-3995-OUT;n:type:ShaderForge.SFN_RemapRange,id:6457,x:31941,y:33017,varname:node_6457,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-4513-OUT;n:type:ShaderForge.SFN_Tex2d,id:6521,x:31207,y:32460,ptovrint:False,ptlb:node_6521,ptin:_node_6521,varname:node_6521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:19099d4786ead2146a0ce88af33054b1,ntxv:0,isnm:False;proporder:5964-358-1813-7677-5597-3275-4041-7420-7973-8433-6521-7029;pass:END;sub:END;*/

Shader "Shader Forge/CornerPattern" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _EmissivePattern ("Emissive Pattern", 2D) = "white" {}
        _GlowSpeed ("Glow Speed", Range(0, 1)) = 0.0489468
        _Glow ("Glow", 2D) = "white" {}
        _GlowColour ("Glow Colour", Color) = (0.1375432,0.7262916,0.7794118,1)
        _node_7420 ("node_7420", 2D) = "white" {}
        _Glow_copy ("Glow_copy", 2D) = "white" {}
        _GlowColour_copy ("Glow Colour_copy", Color) = (0.1375432,0.7262916,0.7794118,1)
        _node_6521 ("node_6521", 2D) = "white" {}
        _GlowSpeed_copy ("Glow Speed_copy", Range(0, 1)) = 0.476329
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _EmissivePattern; uniform float4 _EmissivePattern_ST;
            uniform float _GlowSpeed;
            uniform sampler2D _Glow; uniform float4 _Glow_ST;
            uniform float4 _GlowColour;
            uniform sampler2D _node_7420; uniform float4 _node_7420_ST;
            uniform float _GlowSpeed_copy;
            uniform sampler2D _Glow_copy; uniform float4 _Glow_copy_ST;
            uniform float4 _GlowColour_copy;
            uniform sampler2D _node_6521; uniform float4 _node_6521_ST;
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
                UNITY_FOG_COORDS(7)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
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
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
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
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _node_6521_var = tex2D(_node_6521,TRANSFORM_TEX(i.uv0, _node_6521));
                float4 node_8896 = _Time;
                float2 node_7730 = (i.uv0+(node_8896.g/((1.0 - _GlowSpeed_copy)*9.0+1.0))*float2(-1,-1));
                float4 _Glow_copy_var = tex2D(_Glow_copy,TRANSFORM_TEX(node_7730, _Glow_copy));
                float3 diffuseColor = (_node_6521_var.b.r*((_Glow_copy_var.g*1.5+-1.0)+_GlowColour_copy.rgb)); // Need this for specular when using metallic
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
                float4 _node_7420_var = tex2D(_node_7420,TRANSFORM_TEX(i.uv0, _node_7420));
                float4 _EmissivePattern_var = tex2D(_EmissivePattern,TRANSFORM_TEX(i.uv0, _EmissivePattern));
                float4 node_8488 = _Time;
                float2 node_1041 = (i.uv0+(node_8488.g/((1.0 - _GlowSpeed)*9.0+1.0))*float2(-1,-1));
                float4 _Glow_var = tex2D(_Glow,TRANSFORM_TEX(node_1041, _Glow));
                float3 emissive = ((_node_7420_var.rgb.r*0.5+0.5)*(_EmissivePattern_var.r.r*(((_Glow_var.g*1.5+-1.0)+_GlowColour.rgb)*1.3+-0.4)));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,_EmissivePattern_var.g.r);
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
            ZWrite Off
            
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
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _EmissivePattern; uniform float4 _EmissivePattern_ST;
            uniform float _GlowSpeed;
            uniform sampler2D _Glow; uniform float4 _Glow_ST;
            uniform float4 _GlowColour;
            uniform sampler2D _node_7420; uniform float4 _node_7420_ST;
            uniform float _GlowSpeed_copy;
            uniform sampler2D _Glow_copy; uniform float4 _Glow_copy_ST;
            uniform float4 _GlowColour_copy;
            uniform sampler2D _node_6521; uniform float4 _node_6521_ST;
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
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _node_6521_var = tex2D(_node_6521,TRANSFORM_TEX(i.uv0, _node_6521));
                float4 node_8896 = _Time;
                float2 node_7730 = (i.uv0+(node_8896.g/((1.0 - _GlowSpeed_copy)*9.0+1.0))*float2(-1,-1));
                float4 _Glow_copy_var = tex2D(_Glow_copy,TRANSFORM_TEX(node_7730, _Glow_copy));
                float3 diffuseColor = (_node_6521_var.b.r*((_Glow_copy_var.g*1.5+-1.0)+_GlowColour_copy.rgb)); // Need this for specular when using metallic
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
                float4 _EmissivePattern_var = tex2D(_EmissivePattern,TRANSFORM_TEX(i.uv0, _EmissivePattern));
                fixed4 finalRGBA = fixed4(finalColor * _EmissivePattern_var.g.r,0);
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
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _EmissivePattern; uniform float4 _EmissivePattern_ST;
            uniform float _GlowSpeed;
            uniform sampler2D _Glow; uniform float4 _Glow_ST;
            uniform float4 _GlowColour;
            uniform sampler2D _node_7420; uniform float4 _node_7420_ST;
            uniform float _GlowSpeed_copy;
            uniform sampler2D _Glow_copy; uniform float4 _Glow_copy_ST;
            uniform float4 _GlowColour_copy;
            uniform sampler2D _node_6521; uniform float4 _node_6521_ST;
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
                
                float4 _node_7420_var = tex2D(_node_7420,TRANSFORM_TEX(i.uv0, _node_7420));
                float4 _EmissivePattern_var = tex2D(_EmissivePattern,TRANSFORM_TEX(i.uv0, _EmissivePattern));
                float4 node_8488 = _Time;
                float2 node_1041 = (i.uv0+(node_8488.g/((1.0 - _GlowSpeed)*9.0+1.0))*float2(-1,-1));
                float4 _Glow_var = tex2D(_Glow,TRANSFORM_TEX(node_1041, _Glow));
                o.Emission = ((_node_7420_var.rgb.r*0.5+0.5)*(_EmissivePattern_var.r.r*(((_Glow_var.g*1.5+-1.0)+_GlowColour.rgb)*1.3+-0.4)));
                
                float4 _node_6521_var = tex2D(_node_6521,TRANSFORM_TEX(i.uv0, _node_6521));
                float4 node_8896 = _Time;
                float2 node_7730 = (i.uv0+(node_8896.g/((1.0 - _GlowSpeed_copy)*9.0+1.0))*float2(-1,-1));
                float4 _Glow_copy_var = tex2D(_Glow_copy,TRANSFORM_TEX(node_7730, _Glow_copy));
                float3 diffColor = (_node_6521_var.b.r*((_Glow_copy_var.g*1.5+-1.0)+_GlowColour_copy.rgb));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
