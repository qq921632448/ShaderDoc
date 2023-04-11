using UnityEditor;
using UnityEngine;

public class ShaderDoc : EditorWindow
{
    /// <summary>
    /// ��ǰ�༭������ʵ��
    /// </summary>
    private static ShaderDoc instance;
    private string[] buttons = { "GPU(���������ܲ���)","Pipline(��Ⱦ����)","Properties(�������)","Semantics(����)","Tags(��ǩ)","Render State(��Ⱦ����)","Compile Directives(����ָ��)",
                                "Transformations(�ռ�任)","Other(�����﷨)","BuildIn Variables(���ñ���)","Predefined Macros(�ٷ�Ԥ�����)","Platform Differences(ƽ̨��Ĳ�����)",
                                "Math(��ѧ����)","Lighting(����)","Miscellaneous(����)","Error Debug(����������Ϣ)","WWW(��ҳ�Ƽ�)","Setup(����)","Announcement(ע������)","About(����)"};
    int selectedButtonIndex = 0;
    float splitPos = 0.15f;
    private Vector2 leftScroll; // ������ͼ�Ĺ���λ��
    private Vector2 rightScroll; // ������ͼ�Ĺ���λ��

    // �����ı���ɫ
    Color titleColor = Color.black;
    string titleStr = "#000000";
    Color descColor = Color.gray;
    string descColorStr = "#7B7B7B";
    Color bgColor = new Color(160f / 255f, 240f / 255f, 160f / 255f);
    string bgStr = "#8CF0A0";
    int titleScale = 25;
    int descScale = 18;
    int interspaceScale = 5;
    [MenuItem("�ʼ�/shader")]
    static void ShowExcelTools()
    {
        //��ȡ��ǰʵ��
        instance = EditorWindow.GetWindow<ShaderDoc>();
        instance.Show();
        instance.GetParameters();
    }

    private void OnEnable()
    {

    }

    void OnGUI()
    {
        if (instance == null)
            instance = ShaderDoc.GetWindow<ShaderDoc>();

        DrawPanel();
        
    }
    void DrawPanel()
    {
        descColorStr = ColorUtility.ToHtmlStringRGB(descColor);
        GUILayout.BeginHorizontal();

        // ��ർ���������
        GUILayout.BeginVertical(GUILayout.Width(position.width * splitPos));
        leftScroll = EditorGUILayout.BeginScrollView(leftScroll, GUILayout.ExpandWidth(true));
        //GUILayout.Label("����", EditorStyles.boldLabel);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (GUILayout.Button(buttons[i], i == selectedButtonIndex ? EditorStyles.toolbarButton : EditorStyles.miniButton))
            {
                selectedButtonIndex = i;
            }
        }
        EditorGUILayout.EndScrollView();
        GUILayout.EndVertical();

        Rect splitRect = new Rect(position.width * splitPos, 0f, 2f, position.height);
        EditorGUI.DrawRect(splitRect, Color.gray);

        // �Ҳ���������
        // ������ͼ
        rightScroll = EditorGUILayout.BeginScrollView(rightScroll, GUILayout.ExpandWidth(true));
        GUILayout.BeginVertical();
        //GUILayout.Label("����", EditorStyles.boldLabel);
        switch (selectedButtonIndex)
        {
            case 0:
                ShowGPU();
                break;
            case 1:
                ShowPipline();
                break;
            case 2:
                ShowProperties();
                break; 
            case 3:
                ShowSemantics();
                break; 
            case 4:
                ShowTags();
                break; 
            case 5:
                ShowRenderState();
                break;
            case 6:
                ShowCompileDirectives();
                break;
            case 7:
                ShowTransformations();
                break;
            case 8:
                ShowOther();
                break;
            case 9:
                ShowBuildInVariables();
                break;
            case 10:
                ShowPredefinedMacros();
                break;
            case 11:
                ShowPlatformDifferences();
                break;
            case 12:
                ShowMath();
                break;
            case 13:
                ShowLighting();
                break;
            case 14:
                ShowMiscellaneous();
                break;
            case 15:
                ShowErrorDebug();
                break;
            case 16:
                ShowWWW();
                break;
            case 17:
                ShowSetup();
                break;
            case 18:
                ShowAnnouncement();
                break;
            case 19:
                ShowAbout();
                break;
            default:
                break;
        }
        EditorGUILayout.EndScrollView();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    void ShowGPU()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GPU</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Graphic Processing Unit,���GPU�����ķ���Ϊͼ�δ�������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BIOS</size>\n<color=#"+descColorStr+"><size="+descScale+">BIOS��Basic Input Output System�ļ�ƣ�Ҳ���ǻ����������ϵͳ��" +
            "�Կ�BIOS��Ҫ���ڴ����ʾоƬ����������֮��Ŀ��Ƴ������⻹�����Կ����ͺš�������������Լ�����ʱ�����Ϣ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PCB</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Printed Circuit Board,�Կ�PCB����ӡ�Ƶ�·�壬�������ڹ̶�����С����⣬PCB����Ҫ�������ṩ���ϸ���������໥�������ӡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����</size>\n<color=#"+descColorStr+"><size="+descScale+">Crystal��ʯӢ�����ļ�ƣ���ʱ�ӵ�·������Ҫ�Ĳ��֡�" +
            "�Կ�����Ϊ27MH�������������Կ��������ṩ��׼Ƶ�ʣ����������꾡�ߣ�����Ƶ�ʲ��ȶ����������豸����Ƶ�ʲ��ȶ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���Կ���������ֱ������������ݶ��Կ���Ҫ���˲����ȶ����������ã�ֻ���ڱ�֤�����ȶ�������£��Կ����������Ĺ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���ܲ���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�Կ��ܹ�</size>\n<color=#"+descColorStr+"><size="+descScale+">����ָ��ʾоƬ���ִ���Ԫ����ɺ͹���ģʽ���ڲ�����ͬ������£��ܹ�Խ�Ƚ���Ч�ʾ�Խ�ߣ�����Ҳ��Խǿ��" +
            "��ͬ�ܹ����Կ� ����Ҫ��ָ���ɴ�������������оƵ�ʡ��Դ桢λ����������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����Ƶ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "�Կ��ĺ���Ƶ����ָ��ʾ���ĵĹ���Ƶ�ʡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�Դ�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "Ҳ������֡���棬���������������洢�Կ�оƬ��������߼�����ȡ����Ⱦ���ݡ�" +
           "��ʾоƬ���������ݺ�Ὣ���ݱ��浽�Դ��У�Ȼ����RAMDAC(��ģת����)���Դ��ж�ȡ�����ݲ�������\n" +
           "�ź�ת��Ϊģ���źţ��������Ļ��ʾ������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�Դ�λ��</size>\n<color=#"+descColorStr+"><size="+descScale+">�Դ�λ�����Դ���һ��ʱ�����������ܴ������ݵ�λ����λ��Խ����˲���ܴ������������Խ��" +
           "�Դ���� = �Դ�Ƶ�� * �Դ�λ�� / 8������: 500MHz * 256bit / 8=16GB/s</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�Դ��ٶ�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "�Դ��ٶ�һ����ns(����)Ϊ��λ�����õ��Դ��ٶ���7ns��5ns��1.1ns�ȣ�ԽС�ٶ�Խ�죬����Խ�á�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�Դ�Ƶ��</size>\n<color=#"+descColorStr+"><size="+descScale+">�Դ�Ƶ����һ���̶��Ϸ�Ӧ���Դ���ٶȣ���MH(�׺���)Ϊ��λ���Դ�Ƶ�����Դ�ʱ����������صģ����߳ɵ�����ϵ:" +
           "�Դ�Ƶ�� = 1 / �Դ�ʱ�����ڡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowPipline()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Ӧ�ó���׶�(Application Stage)</color>",
            new GUIStyle(EditorStyles.boldLabel){ richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Application Stage</size>\n<color=#"+descColorStr+"><size="+descScale+">�˽׶�һ����CPU����Ҫ����Ļ�ϻ��Ƶļ����塢" +
            "�����λ�á������������������ߵļ��ν׶�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���ν׶�(Geometry Stage)</color>", new GUIStyle(EditorStyles.boldLabel) { richText = true });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ģ�ͺ���ͼ�任(Model and View Transform)</size>\n<color=#"+descColorStr+"><size="+descScale+">ģ�ͺ���ͼ�任�׶η�Ϊģ�ͱ任����ͼ�任\n" +
            "ģ�ͱ任��Ŀ���ǽ�ģ�ʹӱ��ؿռ�任������ռ䵱�У�����ͼ�任��Ŀ���ǽ����������������ԭ��(���ǲü���ͶӰ�������򵥸�Ч)��\n" +
            "��ģ�ʹ�����ռ�任������ռ䣬�Է���������������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������ɫ(Vertex Shading)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ɫ�׶ε�Ŀ������ȷ��ģ���϶��㴦�Ĺ���Ч��,��������(��ɫ�����������������)�ᱻ���͵���դ���׶��Խ��в�ֵ������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���Ρ�����ϸ����ɫ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "[��ѡ��]��Ϊ������ɫ��(Geometry hader)������ϸ����ɫ��(Tessellation Shader)����Ҫ�ǶԶ������������ɾ���޸ĵȲ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ͶӰ (Projection)</size>\n<color=#"+descColorStr+"><size="+descScale+">ͶӰ�׶η�Ϊ����ͶӰ��͸��ͶӰ\n" +
            "ͶӰ��ʵ���Ǿ���任�����ջ�ʹ����λ�ڹ�һ�����豸������,֮���Խ�ͶӰ������Ϊ����Z�����꽫��������\n" +
            "Ҳ����˵�˽׶���Ҫ��Ŀ���ǽ�ģ�ʹ���ά�ռ�Ͷ�䵽�˶�ά�Ŀռ��еĹ���\n(����������Ȼ����ά�ģ�ֻ����ʾ�Ͽ��Ƕ�ά��)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�ü� (Clipping)</size>\n<color=#"+descColorStr+"><size="+descScale+">�ü�����ͼԪ�������λ�÷�Ϊ�������:\n" +
            "1.��ͼԪ��ȫλ�������ڲ�,��ô������ֱ�ӽ�����һ���׶Ρ�\n" +
            "2.��ͼԪ��ȫλ�������ⲿ,�򲻻�����¸��׶Σ�ֱ�Ӷ�����\n" +
            "3.��ͼԪ����λ�������ڲ�,����Ҫ��λ�������ڵ�ͼԪ���вü�����" +
            "���յ�Ŀ�ľ��ǶԲ���λ�������ڲ���ͼԪ���вü���������ʹ���������ⲿ����Ҫ��Ⱦ��ͼԪ���вü�������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��Ļӳ�� (Screen Mapping)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ļӳ��׶ε���ҪĿ�ģ��ǽ�֮ǰ����õ�������ӳ�䵽��Ӧ����������ϵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��դ���׶�(Rasterizer Stage)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�������趨 (Triangle Setup)(Model and View Transform)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�˽׶���Ҫ�ǽ��Ӽ��ν׶εõ���һ��������ͨ���������õ�һ��������������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�����α��� (Triangle Traversal)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�˽׶ν����������ر������������Լ����������Ƿ���һ���õ��������������ǣ�������ҹ��̱���Ϊ�����α�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������ɫ(Pixelshading)(Triangle Traversal)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ӧ��ShaderLab�е�frag����,��ҪĿ���Ƕ������ص����������ɫ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��� (Merging)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ҫ�����Ǻϳɵ�ǰ�����ڻ������е���֮ǰ��������ɫ�׶β�����Ƭ����ɫ���˽׶λ�����ɼ�������(��Ȳ��ԡ�ģ����Ե�)�Ĵ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

    }

    void ShowProperties()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Properties ���� _Name { \"display name\" , PropertyType} = DefaultValue</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Int(\"Int\",Int) = 1</size>\n<color=#"+descColorStr+"><size="+descScale+">����:����\n" +
            "Cg/HLSL:int</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Float(\"Float\"��Float ) = 0</size>\n<color=#"+descColorStr+"><size="+descScale+">����:������ֵ\n" +
            "Cg/HLSL:�ɸ�����Ҫ���岻ͬ�ĸ��㾫��\n" +
            "foat 32λ��������.��������������λ���Լ�UV����\n" +
            "half 16λ��������,�����ڱ�������λ�ã������\n" +
            "fixed 12λ��������,��������������ɫ�ȵ;��ȵ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Slider(\"slider\"��Range(0,1)) = 0</size>\n<color=#"+descColorStr+"><size="+descScale+">����:��ֵ������\n" +
            "������Float���ͣ�ֻ��ͨ��Range(min,max)�����ƻ���������Сֵ�����ֵ</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Color(\"Color\",Color) =(1,1,1,1)</size>\n<color=#"+descColorStr+"><size="+descScale+">����:��ɫ����\n" +
            "Cg/HLSL:foat4/half4/fixed4</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Vector(\"Vector\", Vector) = (0,0,0,0)</size>\n<color=#"+descColorStr+"><size="+descScale+">����:��ά����\n" +
            "��Properties���޷������ά������ά������ֻ�ܶ�����ά����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainTex (\"Texture\"��2D)=\"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">����:2D����\n" +
            "Cg/HLSL:sampler2D/sampler2D_half/sampler2D_float\n" +
            "Ĭ��ֵ��white��black��gray��bump�Լ��գ��վ���white\n" +
            "\"bump\"�� Unity���õķ���������û���ṩ�κη�������ʱ��\"bump\"��Ӧģ���Դ��ķ�����Ϣ</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainTex3D(��Texture����3D)= \"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">����:3D����\n" +
            "Cg/HLSL:sampler3D/sampler3D_half/sampler3D_float" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainCube (\"Texture\"��Cube) = \"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">����:����������\n" +
            "Cg/HLSL:samplerCUBE/samplerCUBE_half/samplerCUBE_float" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Attribute</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Header(xxx)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����ڲ�������е�ǰ���Ե��Ϸ���ʾ����xxx��ע��ֻ֧�ֹ��ġ�����ո��Լ��»��ߡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[HideInInspector]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ڲ����淹�����ش������ԣ��ڲ�ϣ����¶ĳ������ʱ���Կ��ٽ������ԡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Space(n)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ʹ�����淹����֮ǰ�м����nΪ�������ֵ��С��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[HDR]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���Ϊ����Ϊ�߶�̬��Χ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[PowerSlider(3)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������,��������range����ǰ�棬���ڿ��ƻ�������ֵ������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[IntRange]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ʹ����Range����֮�ϣ���ʹ�ڲ����淹�л���ʱֻ������������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Toggle]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����,������ֵ����ǰ,��ʹ��������е���ֵ��ɿ��أ�0�ǹأ�1�ǿ���</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Enum(off, 0 , On, 1)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ֵö��,��ֱ����cg��ʹ�ô˹ؼ�����������֡�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[KeywordEnum (Enum0, Enum1, Enum2, Enum3, Enum4, Enum5, Enum6, Enum7, Enum8)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ؼ���ö��,����ඨ��8��,��Ҫ#pragma mult_compile _ENUM_ENUMO _ENUM_ENUM1 ...��������������ؼ���,��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Enum(UnityEngine.Rendering.CullMode)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ö�٣�����Enum()��ֱ�ӵ���Unity�ڲ���ö��.��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[NoScaleOffset]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֻ������������ǰ��ʹ�����زľ�����е�Tiling��Offset��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Normal]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֻ�ܼ�����������ǰ����Ǵ��������������շ�����ͼ�ģ����û�ָ���˷Ƿ��ߵ�����ʱ���ڲ�������Ͻ��о�����ʾ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Gamma]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Float��Vector����Ĭ������²��������ɫ�ռ�ת��������ͨ�����[Gamma]��ָ��������ΪsRGBֵ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[PerRendererData]]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǵ�ǰ���Խ��Բ������Կ����ʽ������ÿ����Ⱦ�����ݡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowSemantics()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Ӧ�ó��򵽶�����ɫ�� appdata,a2v</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 vertex : POSITION;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ģ�Ϳռ��еĶ���λ�á�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">uint vid : SV_VertexID;;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������ID��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float3 normal : NORMAL;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ķ�����Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 tangent : TANGENT;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����������Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord : TEXCOORDO;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����UV1��Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord1 : TEXCOORD1;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����UV2��Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord2 : TEXCOORD2;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����UV3��Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord3 : TEXCOORD3;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����UV4��Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed4 color : COLOR;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ɫ��Ϣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_base</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������λ�ã����ߺ�һ���������ꡣ</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_tan</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������λ�ã����ߣ����ߺ�һ���������ꡣ</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_full</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����λ�á����ߡ����ߡ�������ɫ���ĸ��������ꡣ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>������ɫ�����ݸ�ƬԪ��ɫ�� v2f</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 vertex : SV_POSITION;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������βü��ռ��µ�����,Ĭ�Ͽ�����POSITIONҲ����(PS4�²�֧��)������Ϊ��֧������ƽ̨���������ʹ��SV_POSITION��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float2 uv : TEXCOORD0;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "TEXCOORDO~N������TEXCOORDO��TEXCOORD1��TEXCOORD2...�ȵȣ���Ҫ���ڸ߾������ݡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed3 color : COLOR0;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "COLORO~N������COLOR0��COLOR1��COLOR2...�ȵȣ���Ҫ���ڵ;������ݡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float face : VFACE;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����Ⱦ���泯�����������Face�ڵ������ֵ1�����Զ����������������ֵ-1��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_VPOS_TYPE screenPos : VPOS;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.��ǰƬԪ����Ļ�ϵ�λ��(��λ������,�ɳ���_ScreenParams.xy������һ��),�˹��ܽ�֧��#pragma target 3.0�����ϱ���ָ�\n" +
            "2.�󲿷�ƽ̨��VPOS���ص���һ����ά����������ƽ̨�Ƕ�ά������������Ҫ��UNITY_VPOS_TYPE��ͳһ���֡�\n" +
            "3.��ʹ��VPOSʱ���Ͳ�����v2f�ж���SV_POSIT1ON���������ͻ��������Ҫ�Ѷ�����ɫ���������()�Ĳ����У�����SV_POSITION����Out��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">uint vid : sv_VertexID;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ɫ�����Խ��վ��С������š���Ϊ�޷��������ı���,����Ҫ�������ComputeBufers�л�ȡ����Ķ�������ʱ�Ƚ����ã�\n" +
            "�������֧��#pragmatarget 3.5�����ϡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ע������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.OpenGLES2.0֧�����8����\n" +
            "2.0penGL ES3.0֧�����16����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>ƬԪ��ɫ����������� fragOutput</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed4 color : SV_Target;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Ĭ��RenderTarget,Ҳ��Ĭ���������Ļ�ϵ���ɫ��\n" +
            "ͬʱ֧��SV_Target1��SV_Target2...�ȵȡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed depth : SV_Depth;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ͨ����ƬԪ��ɫ�������SV_DEPTH������Ը������ص����ֵ,ע��˹�����Ի��������ܣ���û���ر����������¾�����Ҫ�á�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowTags()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Tags</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Tags {\"TagName1\"=\"Value1\"  \"TagName2\"=\"Value2\"}</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "tags���﷨�ṹ��ͨ��Tags{}����ʾ��Ҫ��ӵı�ʶ,�������ڿ��Զ���Tag,����(TagName) ��ֵ(Value) �ǳɶԳɶԳ��ֵģ�����ȫ�����ַ�����ʾ.\n" +
            "ͬʱ֧��SV_Target1��SV_Target2...�ȵȡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Queue</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Queue</size>\n<color=#"+descColorStr+"><size="+descScale+">������Ⱦ˳��ָ��������������һ����Ⱦ����\n" +
            "��Ⱦ����ֱ��Ӱ�������е��ظ����ƣ�����Ķ��пɼ����������ȾЧ�ʡ�\n" +
            "��Ⱦ������<=2500�Ķ��󶼱���Ϊ�ǲ�͸��������(��ǰ����Ⱦ)��>2500�ı���Ϊ�ǰ�͸������(�Ӻ���ǰ��Ⱦ)��" +
            "\"Queue\" = \"Geometry+1\" ��ͨ����ֵ������ֵķ�ʽ���ı����</size></color>", contentStyle);
        EditorGUILayout.EndVertical(); 
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Background\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֵΪ1000���˶��еĶ������Ƚ�����Ⱦ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Geometry\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֵΪΪ2000��ͨ�����ڲ�͸�����󣬱��糡���е�������ɫ�ȡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"AlphaTest\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֵΪ2450��͸���Ȳ��ԣ�Ĭ�ϲ�͸��������Ⱦ������Ⱦ�����壬Ҳ����������˵��͸����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Transparent\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֵΪ3000�������ڰ�͸��������Ⱦʱ�Ӻ���ǰ������Ⱦ��������Ҫ��ϵĶ������˶��С�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Overlavy\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ֵΪ4000,����Ⱦ�������ڵ���Ч���������Ⱦ�Ķ���Ӧ�÷�������(������ͷ���ε�)��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>RenderType</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">RenderType</size>\n<color=#"+descColorStr+"><size="+descScale+">�����������ShaderҪȾ�Ķ���������ʲô���ģ����������������ǰѸ��ֲ�ͬ�����尴������Ҫ�����������з���һ����\n" +
            "��Ȼ��Ҳ���Ը�����Ҫ�ĳ��Զ�������ƣ�����������Ӱ�쵽Shader��Ч����\n" +
            "��Tag��������������滻���ʹ���(Camera,SetReplacementShader)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Opaque\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������͸����ɫ����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Transparent\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���󲿷�͸�������塢����������Ч���嶼ʹ�������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TransparentCutout\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "͸����ɫ����������ֲ���ȡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Background\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������պ���ɫ����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Overlay\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GUI��������ɫ���ȡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeOpaque\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain�����е����ɡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeTransparentCutout\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain�����е���Ҷ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeBillboard\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain�����е�����������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Grass\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain�����еĲݡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"GrassBillboard'\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain�����е�������ݡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>DisableBatching</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">DisableBatching</size>\n<color=#"+descColorStr+"><size="+descScale+">ͨ���ñ�ǩ��ֱ��ָ���Ƿ�Ը�SubShaderʹ��������\n" +
            "������Shader��ģ�͵Ķ��㱾����������һЩλ�ƶ�����������ģ����������ʱ�����Ч������ȷ�������\n" +
            "������Ϊ������Ὣ����ģ���ػ�Ϊ��������ռ䣬��ˡ���������ռ䡱����ʧ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"LODFading\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����LOD����ʱ����������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>ForceNoShadowCasting</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForceNoShadowCasting</size>\n<color=#"+descColorStr+"><size="+descScale+">����ʹ�ø�SubShader�������Ƿ��Ͷ����Ӱ\n" +
            "ǿ�ƹر�Ͷ����Ӱ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"ForceNoShadowCasting\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ǿ�ƹ�����ӰͶ�䡣</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForceNoShadowCasting</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ر���ӰͶ�䡣</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>IgnoreProjector</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">IgnoreProjector</size>\n<color=#"+descColorStr+"><size="+descScale+">ͨ�����ڰ�͸������\n" +
            "�Ƿ����ProjectorͶӰ����Ӱ�졣</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"IgnoreProjector\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ͶӰ��Ӱ֪�졣</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"IgnoreProjector\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ͶӰ�����ڡ�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>CanUseSpriteAtlas</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CanUseSpriteAtlas</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ƿ�����ڴ��ͼ���ľ��顣</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"CanUseSpriteAtlas\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "֧�־�����ͼ����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"CanUseSpriteAtlas\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��֧�־�����ͼ����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>PreviewType</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PreviewType</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����������е�Ԥ����ģ����ʾ,Ĭ�ϲ�д���߲�ΪPlane��Skyboxʱ��ΪԲ��\n" +
            "(PS���°����ֱ���޸�Ԥ����״)</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PreviewType\"=\"Plane\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ƽ�档</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PreviewType\"=\"Skybox\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��պС�</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>PerformanceChecks</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PerformanceChecks</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ƿ��shader�ڵ�ǰƽ̨�������ܼ�⣬���ڲ����淹���о�����ʾ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PerformanceChecks\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ܼ����ʾ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PerformanceChecks\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ر����ܼ����ʾ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>LightMode(Pass��)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForwardBase</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ǰ����Ⱦ����pass����㻷���⣬����Ҫ��ƽ�й⣬�𶥵��� Lightmaps" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForwardAdd</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ǰ����Ⱦ����pass��������������ع�Դ��ÿ��pass��Ӧһ����Դ����Դ���pass�ᱻ��ε��� Ч�ʱ�͡�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Deferred</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ʱ��Ⱦ����Pass����ȾG-buffer" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ShadowCaster</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������������Ϣ��Ⱦ����Ӱӳ���������������У������Ⱦ��Shadowmap��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PrepassBase</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(�ɰ�)�ӳ���Ⱦ����pass����Ⱦ���ߺ͸߹ⷴ���ָ�����֡�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PrepassFinal</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(�ɰ�)�ӳ���Ⱦ����passͨ���ϲ����� ���� �Է�������Ⱦ�õ�������ɫ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Vertex</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(�ɰ�)����������Ⱦ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">MotionVectors</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�˶�ʸ����Ⱦͨ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">VertexLMRGBM</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ɰ涥��׷Ⱦ��֧�ֺ�����ա�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">VertexLM</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�հ�ҳ��׷Ⱦ��֧�ֺ決���գ�����Ϊ˫LDR��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Always</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������Ⱦ·����pass������Ⱦ������������ա�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Normal</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ս����Ĺ�����ɫ��ͨ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Deffered</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ӳ���ɫ��ͨ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Meta</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ڲ��������ʺͷ���ֵ����ɫ��ͨ����������ӳ������롣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ScriptableRenderPipeline</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Զ���ű�ͨ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ScriptableRenderPipelineDefaultUnlit</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ģʽ������ΪĬ��δ����û�й�ģʽʱ�������Զ���ű��ܵ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowRenderState()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Cull</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Cull Back | Front | On | Off </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����޳�ģʽ\n" +
            "Back: ��ʾ�޳����棬Ҳ������ʾ���棬��Ҳ����õ����á�\n" +
            "Front: ��ʾ�޳�ǰ�棬ֻ��ʾ���档\n" +
            "Off: ��ʾ�ر��޳���Ҳ���������涼��Ⱦ</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����ģ��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Stencil</size>\n<color=#"+descColorStr+"><size="+descScale+">ͨ��д��Pass�����ͷ��CGPROGRAM֮ǰ��\n" +
            "ģ�建����(StencilBuffer����Ϊ��Ļ�ϵ�ÿ�����ص㱣��һ���޷�������ֵ,���ֵ�ľ��������ӳ���ľ���Ӧ�ö���\n" +
            "����Ⱦ�Ĺ�����,���������ֵ��һ��Ԥ���趨�Ĳο�ֵ��Ƚ�,���ݱȽϵĽ���������Ƿ������Ӧ�����ص����ɫֵ,����ȽϵĹ��̱���Ϊģ�����\n" +
            "��StencilBuffer��ֵ��ReadMask�����㣬Ȼ��Ref�Ž���Comp�Ƚϣ����Ϊtueʱ��Pass�������ֽ�Fail����\n" +
            "������ֵ��д��StencilBufferǰ����WriteMask�����㡣\n" +
            "stencil��\n\tRef referenceValue\n\tReadMask  readMask\n\tWriteMask writeMask\n\tComp comparisonFunction\n\tPass stencilOperation\n\tFail stencilOperation\n\tZFail stencilOperation\n��\n" +
            "Ref:�趨�Ĳο�ֵ,���ֵ��������ģ�建���е�ֵ���бȽ�.ȡֵ��ΧλΪ0-255��������\n" +
            "ReadMask:ReadMask��ֵ�Լ�ģ���е�ֵ���н�λ��(&)����,ȡֵ����Ҳ��0-255��������Ĭ��ֵΪ255��\n" +
            "WriteMask:WriteMask��ֵ�ǵ�д�����建��ʱ���еİ�λ�����,ȡֵ��Χ��0-255������,Ĭ��ֵҲ��255,�������κ��޸ġ�\n" +
            "Comp:����Ref��ģ�建���е�ֵ�ȽϵĲ�������,Ĭ��ֵΪalways��\n" +
            "Pass:��ģ�����(����Ȳ���)ͨ��ʱ.�����(StencilOperationֵ)��ģ�建����ֵ���д���,Ĭ��ֵΪkeep\n" +
            "Fail:��ģ�����(����Ȳ���)ʧ��ʱ,�����(StencilOperationֵ)��ģ�建����ֵ���д���Ĭ��ֵΪkeep\n" +
            "ZFail:��ģ�����ͨ������Ȳ���ʧ��ʱ,�����(StencilOperationֵ)��ģ�建��ֵ���д���Ĭ��ֵΪkeep</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">(�Ƚϲ���)Comp</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Less:�൱��\"<\"���������������<�ұߣ�ģ�����ͨ������Ⱦ����\n" +
            "Greater:�൱��\">\"���������������>�ұߣ�ģ�����ͨ������Ⱦ���ء�\n" +
            "Lequal:�൱��\"<=\"���������������<=�ұߣ�ģ�����ͨ������Ⱦ����\n" +
            "Gequal:�൱��\">=\"���������������>=�ұߣ�ģ�����ͨ������Ⱦ����\n" +
            "Equal:�൱��\"=\"���������������=�ұߣ�ģ�����ͨ������Ⱦ����\n" +
            "NotEqual:�൱��\"!=\"���������������!=�ұߣ�ģ�����ͨ������Ⱦ����\n" +
            "Always:���ܹ�ʽ����Ϊ��ֵ��ģ���������ͨ������Ⱦ����\n" +
            "Never:���ܹ�ʽ����Ϊ��ֵ��ģ���������ʧ�ܣ���Ⱦ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ģ�建�����ĸ���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Keep:������ǰ�����е����ݣ���stencilBufferValue���䡣\n" +
            "Zero:��0д�뻺�壬��stencilBufferValueֵ��Ϊ0��\n" +
            "Replace:���ο�ֵд�뻺�壬����referenceValue��ֵ��stencilBufferValue��\n" +
            "IncrSat:stencilBufferValue��1�����stencilBufferValue����255�ˣ���ô����Ϊ255����������255��\n" +
            "DecrSat:stencilBufferValue��1�����stencilBufferValue����Ϊ0����ô����Ϊ0������С��0��\n" +
            "Invert:����ǰģ�建��ֵ (stencilBufferValue) ��λȡ����\n" +
            "IncrWrap:��ǰ�����ֵ��1���������ֵ����255�ˣ���ô���0(Ȼ���������)��\n" +
            "DecrWrap:��ǰ�����ֵ��1���������ֵ�Ѿ�Ϊ0����ô���255(Ȼ������Լ�)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��Ȼ���/color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZTest (Less | Greater | LEqual | GEqual | Equal | NotEqual | Never| Always)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ȳ��ԣ��õ�ǰ���ص����ֵ����Ȼ����е����ֵ���бȽϣ�Ĭ��ֵΪLEqual��\n" +
            "��ͨ�������������ö��UnityEngine.Rendering.CompareFunction\n" +
            "Less:С�ڣ���ʾ�����ǰ���ص����ֵС����Ȼ����е����ֵ����ͨ����������ͬ��\n" +
            "Greater:���ڡ�\n" +
            "Lequal:С�ڵ��ڡ�\n" +
            "Gequal:���ڵ��ڡ�\n" +
            "Equal:���ڡ�\n" +
            "NotEqual:�����ڡ�\n" +
            "Never:��Զ��ͨ����\n" +
            "Always:��Զͨ����</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZTest[unity_GUIZTestMode]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "unity_GUIZTestMode����UI�����У���ֵĬ��ΪLEqual,����UI��CanvasģʽΪOverlayʱ��ֵΪAlways" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZWrite On | Off </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���д�룬Ĭ��ֵΪOn������|�ر����д��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Offset Factor, Units</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ƫ�ƣ�offset =(m *factor)+(r* units)��Ĭ��ֵΪ0.0\n" +
            "m:�Ƕ���ε���ȵ�б��(�ڹ�դ���׶μ���ó�)�е����ֵ,�����Խ������ü���ƽ�У�m�ž�Խ�ӽ�0��\n" +
            "r:���ܲ����ڴ�������ϵ�����ֵ�пɷֱ�Ĳ������Сֵ��r���ɾ���ʵ��OpenGL��ƽָ̨����һ��������\n" +
            "����:һ������0��offset ���ģ���Ƶ�����(�����)��Զһ���λ�ã���Ӧ�أ�һ��С��0��offset ���ģ��������</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��ɫ����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ColorMask RGB|A|R��G��B��A���������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ɫ���֣�Ĭ�ϲ�Ϊ:RGBA����ʾд��RGBA�ĸ�ͨ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">˵��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Դ��ɫ*SrcFactor + Ŀ����ɫ*DstFactor\n" +
            "��ɫ��ϣ�Դ��ɫ��Ŀ����ɫ��ָ���Ĺ�ʽ���л�ϳ����յ�����ɫ��\n" +
            "Դ��ɫ:��ǰShader���������ɫ��\n" +
            "Ŀ����ɫ:�Ѿ�������ɫ�����е���ɫ��Ĭ��ֵΪBlend Off,����ʾ���Ż�ϡ�\n" +
            "�ڻ��ʱ�������ĳ��RT����ϣ�����Blend 3 0ne One,���Ƕ�RenderTarget3΢���</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend SrcFactor DstFactor</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "SrcFactorΪԴ��ɫ��DstFactorΪĿ����ɫ�������߰�Op��ָ���Ĳ������л�ϡ�\n" +
            "��������ɫ������SrcFactor. �Ѵ�������Ļ����ɫ����DstFactor���������߽���������һ��</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend SrcFactor DstFactor, SrcFactorA DstFactorA</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��RGB��Aͨ���ֱ�����ϲ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BlendOp Op</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ʱ�Ĳ����������Ĭ��ֵΪAdd (�ӷ�����)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BlendOp OpColor,OpAlpha</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��RGB��Aͨ���ֱ�ָ������������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">AlphaToMask On|Off</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ֵΪOnʱ����ʹ��MSAAʱ����������ؽ����alphaֵ�����޸Ķ��ز��������ʣ���ֲ������������alpha���Ե���ɫ���ǳ����á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend factors</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������\n" +
            "One:Դ��Ŀ�������ֵ\n" +
            "SrcColor: Դ����ɫֵ\n" +
            "SrcAlpha: Դ��Alphaֵ\n" +
            "DstColor:Ŀ�����ɫֵ\n" +
            "DstAlpha:Ŀ���Aphaֵ\n" +
            "OneMinusSrcColor: 1-Դ��ɫ�õ���ֵ\n" +
            "OneMinusSrcAlpha: 1-ԴAlpha�õ���ֵ\n" +
            "OneMinusDstColor: 1-Ŀ����ɫ�õ�ֵ\n" +
            "oneMinusDstAlpha: 1-Ŀ��Alpha�õ���ֵ" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend Types</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���õļ��ֻ������\n" +
            "Blend SrcApha OneMinusSrcAlpha: Alpha��ϣ�������͸���Ȼ��\n" +
            "Blend One OneMinusDstColor: Soft Additive�Ƚ���͵����\n" +
            "Blend One One: Additive��� ���Լ���\n" +
            "Blend OneMinusDstColor One: ������Soft Additive\n" +
            "Blend DstColor Zero: Multiplicative�˷�\n" +
            "Blend DstColor SrcColor: 2 x Multiplicative2���˷�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend operations</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ϲ����ľ��������\n" +
            "Add: Դ+Ŀ��\n" +
            "Sub: Դ-Ŀ��\n" +
            "RevSub; Ŀ��-Դ\n" +
            "Min: Դ��Ŀ������Сֵ\n" +
            "Max: Դ��Ŀ��������\n" +
            "���½�����DX11.1��: LogicalClear    LogicalSet    LogicalCopy    LogicalCopyInverted    \n" +
            "LogicalNoop    Logicalinvert    LogicalAnd    LogicalNand    LogicalOr    LogicalNor    LogicalXor    \n" +
            "LogicalEquiv    LogicalAndReverse    LogicalAndinverted    LogicalOrReverse    LogicalOrInverted" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowCompileDirectives()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Pragma</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // ��������
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma target 2.0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "shader����Ŀ�꼶��Ĭ��ֵΪ2.5��\n" +
            "����ͨ��#if(SHADER TARGET< 30)������֧�жϡ�\n" +
            "��2.0: ��unity����֧�ֵ�ƽ̨�϶��ܹ�������DX9��ɫ�� model2.0��\n" +
            "       ���޵��㷨&��ͼָ��������8����������û�ж�����ͼȡ����û��Ƭ����ɫ�������û������ϸ����ͼ������\n" +
            "��2.5: ������3.0һģһ������ȴ����������ֻ��8��������û������ϸ����ͼ������\n" +
            "       ��Windows Phone�ϱ����DX11���Լ���9.3��\n" +
            "��3.0: DX9��ɫ�� model3.0������ָ���ͼϸ�ڲ�����10������������ļ���&��ͼָ�\n" +
            "       ��֧��DX11�����ڼ���9.x ��GPU�ϡ�\n" +
            "       ������һЩOpenGL ES2.0�豸�ϲ��ᱻ��ȫ֧�֣�ȡ����������չ�ͱ�ʹ�õ����ԡ�\n" +
            "��3.5: (or es3.0)OpenGL ES3.0��������(DX10 SM4.0��D3Dƽ̨��ֻ��û�м�����ɫ��)��\n" +
            "       ��֧�� DX11 9.x(WinPhone)��OpenGL ES 2.0��\n" +
            "       ֧�� DX11+, OpenGL 3.2+ ��OpenGL ES3+, Metal ��Vulkan, PS4/XB����̨��\n" +
            "       ԭ����������������ͼ����ȵȡ�\n" +
            "��4.0: DX11 shader model 4.0��\n" +
            "       ��֧��DX11 9.x (WinPhone), OpenGL ES 2.0/3.0/3.1, Metal��\n" +
            "       ֧�� DX11+, OpenGL 3.2+, OpenGL ES 3.1+AEP, Vulkan, PS4/XB1 ����̨��\n" +
            "       ӵ�м�����ɫ��������3.0�е������С�\n" +
            "��4.5: (or es3.1)OpenGL ES 3.1�������� (DX11 SM5.0 on D3D platforms, û����Ƕ��ɫ��)��\n" +
            "       ��֧��DX11 before SM5.0, OpenGL before 4.3 (i.e. Mac), OpenGL ES 2.0/3.0��\n" +
            "       ֧��DX11+ SM5.0, OpenGL 4.3+, OpenGL ES 3.1, Metal, Vulkan, PS4/XB1����̨��\n" +
            "       ӵ�м�����ɫ���������д��ͼ��ԭ��ѧ�ȣ�û�м��λ�����Ƕ��ɫ����\n" +
            "��4.6: OpenGL 4.1 ��������(DX11 SM5.0 on D3D platforms,û�м�����ɫ��)��\n" +
            "       ���������Macs֧�ֵ���ߵ�OpenGL�����ˡ�\n" +
            "       ��֧��DX11 before SM5.0, OpenGL before 4.1, OpenGL ES 2.0/3.0/3.1, Metal��\n" +
            "       ֧�� DX11+ SM5.0, OpenGL 4.1+, OpenGL ES 3.1+AEP, PS4/XB1 �ȿ���̨��\n" +
            "��5.0: DX11 shader model 5.0��\n" +
            "       ��֧�� DX11 before SM5.0, OpenGL before 4.3 (i.e. Mac), OpenGL ES 2.0/3.0/3.1, Metal��\n" +
            "       ֧�� DX11+ SM5.0, OpenGL 4.3+, OpenGL ES 3.1+AEP, Vulkan, PS4/XB1����̨��\n" +
            "PS�����е�����OpenGL��ƽ̨(�����ƶ�ƽ̨)����������shader model 3.0�����Դ���\n" +
            "WP8/WinRTƽ̨(DX11���� level 9.x)����������shader model 2.5�����Դ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma require xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����shader��Ҫ�����Թ��ܡ�\n" +
            "��interpolators10: ����֧��10����ֵ��(�Ӷ��㵽ƬԪ)��\n" +
            "��interpolators15: ����֧��15����ֵ��(�Ӷ��㵽ƬԪ)��\n" +
            "��interpolators32: ����֧��32����ֵ��(�Ӷ��㵽ƬԪ)��\n" +
            "��mrt4: ��С֧��4��Multiple Render Targets��\n" +
            "��mrt8: ��С֧��8��Multiple Render Targets��\n" +
            "��derivatives: ƬԪ��ɫ��֧��ƫ������(ddx/ddy)��\n" +
            "��samplelod: ����LOD������\n" +
            "��fragcoord: �����ص�λ��(XYΪ���ϵ�����,ZWΪ��βü��ռ��µ����)���뵽ƬԪ��ɫ���С�\n" +
            "��integers: ֧����������������,����λ/��λ������(PS:���ڲ�����Ҳ���Զ�����ֵ��15��ӵ������б��С�)\n" +
            "��2darray: 2D�������顣\n" +
            "��cubearray: Cubemap�������顣\n" +
            "��instancing: GPUʵ������(֧��SV_InstanceID����ϵͳֵ)\n" +
            "��geometry: ������ɫ����\n" +
            "��compute: ֧�ּ�����ɫ�����ṹ����������ԭ�Ӳ�����\n" +
            "��randomwrite or uav: ���Ա�д����λ�õ�һЩ����ͻ�����(UAV,unordered access vlews)��\n" +
            "��tesshw: ֧��Ӳ����Ƕ������һ������Ƕ(hull/domain)��ɫ�׶Ρ����磬Metal֧����Ƕ������֧�ִ��������׶Ρ�\n" +
            "��tessellation: ֧����Ƕ(hull/domain)��ɫ���׶Ρ���\n" +
            "��msaatex: �ܹ����ʶ��������(Texture2DMS in HLSL)��\n" +
            "��framebufferfetch or fbfetch: ֧��Framebuffer��ȡ(��������ɫ���ж�ȡ����������ɫ������)��\n" +
            "��sparsetex: ���г�פ��Ϣ��ϡ������(DirectX�����еġ�Tier2��֧��;checkaccessfulmapping HLSL����)��\n" +
            "��setrtarrayindexfromanyshader:֧�ִ��κ���ɫ���׶�(�������Ǽ�����ɫ���׶�)������ȾĿ������������\n" +
            "PS:https://docs.unity3d.com/cn/current/Manual/SL-ShaderCompileTargets.html" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������������ڲ���Ҫ������ƿ��صĹؼ��֣��ڱ༩���Ĳ��������ã����ʱ���Զ����ˡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature_local</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ر���(shader_feature)��unity2019��֧�ֵĹ��ܣ�ÿ��shader��������64�����ر��壬��ռ��ȫ�ֱ����������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����������ڴ��ʱ������б��嶼�����ȥ����������feature������\n" +
            "����ؼ���ʱ����������»��ߣ����ʾ����һ���յı��壬��ҪĿ����Ϊ�˽�ʡ�ؽ��֡�\n" +
            "��ʹ��shader����ʱ����ס��unity��ȫ�ֹؼ������ֻ��256��,�������ڲ��Ѿ�����60����,���Լǵò�Ҫ�����ˡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_local</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ر���(multi_compile)��unity2019��֧�ֵĹ��ܣ�ÿ��Shader��������64�����ر��壬��ռ��ȫ�ֱ����������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fog</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����͡�ʹ��Unity�ٷ�����Ч������Ҫ��Window-Rendering-Lighting-Environment��������壬��ѡFog������Ч����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fwdbase novertexlight nodynlightmap nodirlightmap</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������LightMode = ForwardBase��Pass�С�\n" +
            "�ڴ�Pass�н�ֻ��һ��ƽ�е�(������)�Լ����������ƺ�SH����,��ָ��������һ������Unity��ForwardBase����Ҫ�ĸ������ú�\n" +
            "DIRECTIONAL:��ƽ�е��µ�Ч������,forwardBase�±ؿ��ꡣ\n" +
            "    ���磺#ifdef USING_DIRECTIONAL_LIGHT\n" +
            "                           fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);\n" +
            "                 #else\n" +
            "                           fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz - i.worldPos.xyz);\n" +
            "                 #endif\n" +
            "DIRLIGHTMAP_COMBINED: �決�����е�DirecitonalMode����ΪDirectional,�������LightMap��\n" +
            "DYNAMICLIGHTMAP_ON: RealtimeGI�Ƿ�������̬�������ݡ�\n" +
            "LIGHTMAP_ON: ��������ΪLightMap Static��Ŀ�����決����,ʹ�ò���lightmap�ķ�ʽ����GI\n" +
            "LIGHTMAP_SHADOW_MIXING: ͬһƬԪ����Ӱ�Ƿ�ͬʱ������shadow mask(��̬��Ӱ)�� shadow map(��̬��Ӱ)\n" +
            "                                                                  ���ƹ�����ΪMixed,���չ���ģʽ����ΪSubtractive����shadowMaskʱ����,Baked Indirect�������Ч��\n" +
            "LIGHTPROBE_SH: ��������̽��,��̬������ܵ�LghtProbe��Ӱ��,��̬������˲����(��̬������յ��˾�̬��������ĺ決��Ӱ����Ҫͨ��light probe���)��\n" +
            "SHADOWS_SCREEN: ��Ӳ��֧����Ļ��Ӱ�������,ͬʱ������Ӱ�ľ��뷶Χ��ʱ��������Ҫ�õ�shadowmap����ʵʱ��Ӱ��\n" +
            "SHADOWS_SHADOWMASK: ���ƹ�����ΪMixed,���պ決ģʽ����ΪshadowMaskʱ�������õ�shadowmask�����決��Ӱ��\n" +
            "VERTEXLIGHT_ON: �Ƿ��ܵ��𶥵������\n" +
            "����: #pragma multi_compile __ LIGHTMAP_ON VERTEXLIGHT_ON</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fwdadd</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������LightMode = ForwardBase��Pass�С�\n" +
            "�ڴ�Pass���������������������ع���,����ָ���������һ��������Unity��ForwardAdd����Ҫ�ĸ������ú�\n" +
            "DIRECTIONAL: �жϵ�ǰ���Ƿ�Ϊƽ�еơ�\n" +
            "DIRECTIONAL_COOKIE: �жϵ�ǰ���Ƿ�ΪCookieƽ�еơ�\n" +
            "POINT: �жϵ�ǰ���Ƿ�Ϊ��ơ�\n" +
            "POINT_COOKIE: �жϵ�ǰ���Ƿ�ΪCookie��ơ�\n" +
            "SPOT: �жϵ�ǰ�Ƶ���Ϊ�۹��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma skip_variants XXX01 XXX02...</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�޳�ָ���ı��壬��ͬʱ�޳������\n" +
            "����: #pragma skip_variants POINT POINT_COOKIE;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma fragmentoption ARB_precision_hint_fastest</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����,��˼���ǻ��õ;���(һ����ָp16),������ƬԪ��ɫ���������ٶ�,����ʱ�䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma fragmentoption ARB_precision_hint_nicest</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ѵ�,���ø߾���(һ����ָp32),���ܻή�������ٶ�,����ʱ�䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma enable_d3d11_debug_symbols</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����d3d11���ԣ��Ӵ��������ص���������벻�ᱻ�޳��������ڵ��Թ����н���ֱ��������\n" +
            "����: https://renderdoc.org/\n" +
            "����: https://zhuanlan.zhihu.com/p/74622572/" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature EDITOR_VISUALIZATION</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����Material Validation,Scene��ͼ�е�ģʽ�����ڲ鿴������Χ��������ɫ��\n" +
            "ʹ�Զ�����ɫ���������֤�����ݡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma only_renderers</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ָ��ƽ̨��shader��\n" +
            "��d3d11 - Direct3D 11/12\r\n" +
            "��glcore - OpenGL 3.x/4.x\r\n" +
            "��gles - OpenGL ES 2.0\r\n" +
            "��gles3 - OpenGL ES 3.x\r\n" +
            "��metal - iOS/Mac Metal\r\n" +
            "��vulkan - Vulkan\r\n" +
            "��d3d11_9x - Direct3D 11 9.x ���ܼ���ͨ���� WSA ƽ̨��ʹ��\r\n" +
            "��xboxone - Xbox One\r\n" +
            "��ps4 - PlayStation 4\r\n" +
            "��n3ds - Nintendo 3DS\r\n" +
            "��wiiu - Nintendo Wii U" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma exclude_renderers</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�޳���ָ��ƽ̨����ش���,�б�ο����档" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>define</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����һ����NAME���ֶΣ���CG�����п���ͨ��#if defined(NAME)���ж��߲�ͬ�ķ�֧��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME stuff;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "#define ��ʾ�궨���ָ��\r\n" +
            "name    ������.��������ֱ���������ֽ���ʹ��\r\n" +
            "stuff   ����ʱ��Ҫ�Ѻ������滻�ɵ�����,�����ǹؼ��֡��������ؼ��֡���ʶ���������š�����������ʽ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME 1;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����һ����NAME����β�������ֵΪ1��\n" +
            "1.����ͨ��#if defned(NAME)���ж��߲�ͬ�ķ�֧��\n" +
            "2.����ͨ��#if NAME���ж��߲�ͬ�ķ�֧(��ʱֵΪ��0ʱ����Ч��Ϊ0ʱ���ߴ˷�֧)\n" +
            "3.������ֱ��ͨ��NAME���õ�����ֵ�����������1��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#error xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����ڷ�֧���ж��У����ô�����ֱ�����һ��������Ϣ������Ϊxxx��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>include</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#include cginc������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "#include \"UnityCG.cginc\"     �������ʹ�õİ�����������ͽṹ��ȡ�\n" +
            "#include \"Lighting.cginc\"    �����˸������õĹ���ģ�ͣ������д����Surface Shader�Ļ������Զ�������������\n" +
            "#include \"UnityShaderVariables.cginc\"     �ڱ���Unity Shaderʱ���ᱻ�Զ�����������������������õ�ȫ�ֱ�����\n" +
            "#include \"HLSLSupport.cginc\"                        �ڱ���Unity Shaderʱ�ᱻ�Զ����������������˺ܶ����ڿ�ƽ̨����ĺ�Ͷ��塣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowTransformations()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�ռ�任(����)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity�����ñ任����</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "View�ռ�  Project�ռ�  Model�ռ�    (�ü��ռ� = ͶӰ�ռ�)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_MVP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ��ģ�͡��۲졤ͶӰ�������ڽ�����/����ʸ����ģ�Ϳռ�任���ü��ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ��ģ�͡��۲�������ڽ�����/����ʸ����ģ�Ϳռ�任���۲�ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_V</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ�Ĺ۲�������ڽ�����/����ʸ��������ռ�任���۲�ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_P</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ��ͶӰ�������ڽ�����/����ʸ���ӹ۲�ռ�任���ü��ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_VP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ�Ĺ۲졤ͶӰ�������ڽ�����/����ʸ��������ռ�任���ü��ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_T_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_MATRIX_MV��ת�þ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_IT_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_MATRIX_MV����ת�þ������ڽ����ߴ�ģ�Ϳռ�任���۲�ռ䣬Ҳ�����ڵõ�UNITY_MATRIX_MV�������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_M</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ��ģ�;������ڽ�����/����ʸ����ģ�Ϳռ�任������ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_ObjectToWorld</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ǰ��ģ�;������ڽ�����/����ʸ����ģ�Ϳռ�任������ռ䡣 �ɰ�������_Object2World��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_WorldToObject</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "unity_ObjectToWorld����������ڽ�����/����ʸ��������ռ�任��ģ�Ϳռ䡣�ɰ�������_World2Object��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�ռ�任(����)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityViewToClipPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ͼ�ռ�任���ü��ռ�(ģ�Ϳռ�->��βü��ռ�)��\n" +
            "float4 UnityWorldToClipPos( in float3 pos )����λ�ô�����ռ�ת���������ռ䡣\n" +
            "float4 UnityViewToClipPos( in float3 pos )����λ�ô� View Space ת��Ϊ Clip Space�� \n" +
            "float4 UnityObjectToClipPos(in float3 pos)����һ������λ�ô�Object Spaceת����Clip Space��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToViewPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����Ӷ���ռ�任��������ռ䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToWorldNormal(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������ߴӶ���ռ�任������ռ� [��λ��]��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToWorldDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����������Ӷ���ռ�任������ռ� [��λ��]��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityWorldSpaceViewDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������ռ�λ�ü��㵽�������������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityWorldSpaceLightDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������ռ�λ�ü��㵽���������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">WorldSpaceViewDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ݶ���ռ�λ�ü��㵽�������������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">WorldSpaceLightDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ݶ���ռ�λ�ü��㵽���������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">TRANSFORM_TEX(float4[texcoord], name[str])</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������/ƫ�����Ա任2D UV��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ObjSpaceLightDir(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����ڶ���ռ��й��������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ObjSpaceViewDir(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����ڶ���ռ�����ͼ��������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnpackNormal(fixed4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ݲ�ͬƽ̨���������ͼ��Ϣ����ȡ���ߡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnpackScaleNormal(half4, half[scale])</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ݲ�ͬƽ̨�Զ��Է�����ͼʹ����ȷ�Ľ��룬�����ŷ��ߡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�����任����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����任</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "f(x)+f(y)=f(x+y)\n" +
            "kf(x)=f(kx)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�������ռ�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����3��3�����ܱ�ʾһ��ƽ�Ʋ������ͽ�����չ����4��4�ľ���\n" +
            "��ԭ������άʸ��ת������ά���꣬Ҳ����������ꡣ\n" +
            "1.����һ���㣬����ά����ת�������������ǰ�w��������Ϊ1��\n" +
            "2.���ڷ���ʸ������Ҫ��w��������Ϊ0����������4��4������б任ʱ��ƽ�Ƶ�Ч���ᱻ����(��Ϊ����ʸ��û��λ��)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�����任����</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ʹ��һ��4x4�ľ�������ʾƽ�ơ���ת�����š��ѱ�ʾ��ƽ�ơ�����ת�ʹ����ŵı任������������任����\n" +
            "[ M(3��3)     T(3��3)\n" +
            "  0(1��3)       1]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ƽ�ƾ���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_translate = float4x4(1,0,0,T.x,\n" +
            "                                                                      0,1,0,T.y,\n" +
            "                                                                      0,0,1,T.z, \n" +
            "                                                                      0,0,0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���ž���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_scale = float4x4(S.x,  0,  0,0,\n" +
            "                                                                 0,S.y,  0,0,\n" +
            "                                                                 0,  0,S.z,0, \n" +
            "                                                                 0,  0,  0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��ת����(X��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationX = float4x4(1,     0,          0,0,\n" +
            "                                                                      0, cos��, sin��,0,\n" +
            "                                                                      0,-sin��, cos��,0, \n" +
            "                                                                      0,     0,          0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��ת����(Y��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationY = float4x4(cos��,0,sin��,0,\n" +
            "                                                                      0,          1,       0,0,\n" +
            "                                                                      -sin��,0, cos��,0, \n" +
            "                                                                      0,          0,       0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��ת����(Z��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationZ = float4x4(cos��,  sin��,0,0,\n" +
            "                                                                      -sin��, cos��,0,0,\n" +
            "                                                                      0,                 0,1,0, \n" +
            "                                                                      0,                 0,0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���ϱ任</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ϱ任��ʽ��P_new = M_translation M_rotation M_scal�� P_old\n" +
            "Լ���任��˳����������ţ�����ת�����ƽ�ơ�\n" +
            "ͬʱ�������������ת����Unity�У������ת˳����zxy����ת�����е������᲻�䡣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowOther()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Other</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CGPROGRAM/ENDCG</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "cg����Ŀ�ʼ�������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CGINCLUDE/ENDCG</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ͨ�����ڶ�����vert/frag������Ȼ�����CG�������뵽����Pass��CG�У����ݵ�ǰPass��������ѡ����ء�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Category{}</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����һ������Subshader��������λ��SubShader���档\n" +
            "��Ⱦ������߼��顣������ɫ�������ж������ɫ��,���Ƕ���Ҫ�ر���Ч�����ͻ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">LOD(Level of Detail)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "shader LOD�������ýű�������LOD����ͨ�����ڲ�ͬ������ʾ��ͬ��SubShader��\n" +
            "Unity�е�������ɫ��ͨ�����·�ʽ������LOD��\n" +
            "VertexLit kind of shaders(VertexLit��ɫ��) = 100\n" +
            "Decal, Reflective VertexLit(�����������Զ����) = 150\n" +
            "Diffuse(����) = 200\n" +
            "Diffuse Detail, Reflective Bumped Unlit, Reflective Bumped VertexLit(������ϸ�ڣ����䰼͹δ���������䰼͹VertexLit) = 250\n" +
            "Bumped, Specular(��͹�����淴��) = 300\n" +
            "Bumped Specular(��͹���淴��) = 400\n" +
            "Parallax(�Ӳ�) = 500\n" +
            "Parallax Specular(�Ӳ�淴��) = 600" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Fallback\"name\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��̥����Shader��û���κ�SubShader��ִ��ʱ����ִ��FallBack��Ĭ��ֵΪOff,��ʾû�б�̥��\n" +
            "����: FallBack\"Diffuse\"" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CustomEditor\"name\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Զ��������壬nameΪ�Զ���Ľű����ơ������ô˹��ܶԲ��������и��Ի��Զ��塣\n" +
            "Shader \"example\" {\n  " +
            "// �˴�Ϊ���Ժ�����ɫ��...\n  " +
            "CustomEditor \"MyCustomEditor\"}\n" +
            "public class name : ShaderGUI\n" +
            "public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)\n" +
            "ͨ��C#�ű��ػ��Զ������UI" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Name\"MyPassName\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ǰPassָ�����ƣ��Ա�����UsePass���е��á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UsePass \"Unlit/MyShader/MYPASS\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������Shader��Pass��Pass����ȫ����д�� Shader��·��ҲҪдȫ��ע����Ӧ��PropertiesҪ������ӡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GrabPass</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GrabPass��ץȡ��ǰ��Ļ�洢��_GrabTexture�У�ÿ���д������Shader����ÿִ֡�С�\n" +
            "GrabPass{\"TextureName\"}ץȡ��ǰ�����洢���Զ����TextureName�У�ÿ֡��ֻ�е�һ��ӵ�д������Shaderִ��һ�Ρ�\n" +
            "GrabPassҲ֧��Name��Tags��\n" +
            "ͨ��GrabPass����һ����Ļץȡ��ͼ��GrabPass{\"_RefractionTex\"}\r\n" +
            "���������ͼƬ��sampler2D _RefractionTex;\r\n" +
            "����ͼ��ʾ������fixed4 col = tex2D(_RefractionTex, i.uv);\r\n" +
            "���Եó���ֱ��ʹ��uv��Ⱦ��GrabPassͼ�ǽ������ͼֱ�ӷ�����Ƭ�ϡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowBuildInVariables()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Camera and Screen</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_WorldSpaceCameraPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������������ռ��е�λ�á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ProjectionParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=1.0,y=Near,z=Far,w=1+1/Far,����Near��Far�ֱ��ǽ��ü�ƽ���Զ�ü�ƽ���������ľ��롣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ScreenParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=width,y=height,z= 1+1/width,w = 1+1/height,����width��height�ֱ��Ǹ��������ȾĿ������ؿ�Ⱥ͸߶ȡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ZBufferParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=1-Far/Near,y=Far/Near,z=x/Far,w=y/Far,�ñ����������Ի�Z�����е����ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_OrthoParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x= width,y=height,zû�ж��壬w=1(�������)��w=0(͸�����)������width��height����������Ŀ�Ⱥ͸߶ȡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraProjection(float4x4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������ͶӰ����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraInvProjection(float4x4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������ͶӰ����������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraWorldClipPlanes[6](float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������6���ü�ƽ��������ռ��µĵ�ʽ������˳�����ҡ��¡��ϡ�����Զ�ü�ƽ�档" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Time</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Time:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t���Ըó������ؿ�ʼ��������ʱ��,4��������(t/20,t,2t,3t)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_SinTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t��ʱ���������ֵ���ĸ�������ֵ�ֱ���(t/8,t/4,t/2,t)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_CosTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t��ʱ���������ֵ���ĸ�������ֵ�ֱ���(t/8,t/4,t/2,t)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_DeltaTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "dt��ʱ��������4�������ֱ���(dt,1/dt,smoothDt,1/smoothDt)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Lighting(ForwardBase & ForwardAdd)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_LightColor0:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Դ��ɫ(UnityLightingCommon.cginc)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_WorldSpaceLightPos0:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����⣺(����ռ䷽��0)��������Դ��(����ռ�λ�ã�1)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_WorldToLight:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ռ䵽��Դ�ռ�ı任���󣬱任�õ����������ڲ�����ǿ˥������(�ɰ�:_LightMatrix0)\n" +
            "�Ѷ��������ռ�任����Դ�ռ�:\n" +
            "float3 lightCoord = mul(unity_WorldToLight, float4(i.worldPos, 1)).xyz; " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Fog and Ambient</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientSky:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(Gradient)�����е�Sky Color��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientEquator:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(Gradient)�����е�Sky Equator��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientGround:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������(Gradient)�����е�Sky Ground��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_LIGHTMODEL_AMBIENT:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����������ɫ(�ݶȻ�������µ������ɫ)(�ɰ����)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>GPU Instancing</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ڶԶ������(����һ��������һ�������ǲ������Բ�һ��)����,���������������Ϊ511������\n" +
            "GPU Instancing������ͬMesh����Ĵ�����Ⱦ���ֲ��˾�̬�������ظ����ʻ���������ڴ��ȱ�ݣ�\n" +
            " ͬʱҲû�ж�̬������ô��Ĺ������ơ��߰汾Unity��Standard Shader��֧��GPU Instancing�ģ�\n" +
            "��Render Doc�����ǿ��Կ���GPU Instancing������������ʽ���Ĳ�ͬ��GPU Instancing����󷢳�Draw Call�����ʱ���õ���glDrawElementsInstanced�ӿڡ�\n" +
            "GPU Instancing ����һ��ǿ��Ĺ����ǲ�ͬ�Ĳ������Բ����Ϻ��������ǾͿ�����һ���ύMesh��\n" +
            "���ƶ��Transform/Color���Բ�ͬ�����壬GPU InstancingĬ��֧�ֲ�ͬ��Transform������������Ҫ��Shader�������Ӧ������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��һ�������ӱ�����Shader֧��instance</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ӱ���ʹ��Shader����֧��Instance��\n" +
            "#pragma multi_compile_instancing\n" +
            "��Ӵ�ָ����ʹ��������ϱ�¶Instaning����,ͬʱ��������Ӧ��Instancing����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�ڶ���-��Ӷ�����ɫ�������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "instancID ���붥����ɫ������ṹ����Ҫ������ʹ��GPUʵ����ʱ�������������Ե�������\n" +
            "UNITY_VERTEX_INPUT_INSTANCE_ID           (�����a2v,appdata�����)\n" +
            "�귭���������ʵ����������һ��SV_InstanceID�����instanceID������\n" +
            "ʹ�ô˺꣬������IINSTANCING_ON�ؼ��֡�����Unity��������instance ID��\n" +
            "Ҫ����instance ID����ʹ��#ifdef INSTANCING_ON�е� vertexInput.instanceID ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������-��Ӷ�����ɫ�������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "instancID���붥����ɫ������ṹ��\n" +
            "UNITY_VERTEX_INPUT_INSTANCE_ID\n" +
            "Ŀ��������һ��SV_InstanceID�����nstanceID�����������������Ե�������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���Ĳ�-�õ�instanceID������������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_SETUP_INSTANCE_ID(v);\n" +
            "����ڶ�����ɫ��/ƬԪ��ɫ��(��ѡ)���ʼ�ĵط�,�������ܷ��ʵ�ȫ�ֵ�unity_InstancelD\n" +
            "������ɫ����������ʵ��ID�����ڶ�����ɫ������ʼʱ��Ҫ�˺ꡣ����Ƭ����ɫ����������ǿ�ѡ�ġ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���岽-����instanceID���㵽ƬԪ��ɫ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_TRANSFER_INSTANCE_ID(v, o);\n" +
            "�ڶ�����ɫ���н�InstanceID������ṹ���Ƶ�����ṹ�������Ҫ����Ƭ����ɫ���е�ÿ��ʵ�����ݣ���ʹ�ô˺ꡣ" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������ instanceID��ƬԪ���������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_SETUP_INSTANCE_ID(i);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_INSTANCING_BUFFER_START(Props)/UNITY_INSTANCING_BUFFER_END(Props)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ڶ��� Constant Buffer��ÿ�� Instance ���е����Ա��붨����һ����ѭ������������� Constant Buffer �С�\n" +
            "��ÿ������Ҫʵ���������Զ���װ����������Ĵ����С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��һ������Ϊ�������ͣ��ڶ�������Ϊ�������֣��ú�ᶨ��һ�� Uniform ���顣\n" +
            "�������START��END�����Ҫ��ÿ�����Լӽ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_ACCESS_INSTANCED_PROP(bufferName, propName)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��һ������Ϊ�������ڻ��������֣��ڶ�������Ϊ�������֡�\n" +
            "ʹ�� Instance ID ��Ϊ������ Uniform ������ȥȡ��ǰInstance ��Ӧ�����ݡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Instancingѡ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��GPU Instancing����һЩ���á�\n" +
            "#pragma instancing_options forcemaxcount;batchSize ǿ�����õ���������Instancing���������,���ֵ��Ĭ��ֵ��500��\n" +
            "#pragma instancing_options maxcount;batchSize ���õ���������Instancing���������,��Vulkan, Xbox One��Switch��Ч" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���ֺ�����ʽ���ص�</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Static Batching</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ԭ��: ���Meshת��Ϊһ��Mesh�µĶ��SubMesh��\n" +
            "����: �����С���ӣ��ڴ��С����(�ظ���Mesh)��\n" +
            "���ó���: ��ֹ�����壬Mesh���ظ��ʵͣ����������ٵĳ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Static Batching������ʱ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ԭ��: ���Meshת��Ϊһ��Mesh�µĶ��SubMesh��\n" +
            "����: ����ʱһ�νϴ��CPU������CPU�϶�ռ��һ���ڴ档\n" +
            "���ó���: ��Ծ�ֹ�ĳ�����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Dynamic Batching</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ԭ��: �ѷ��Ϻ���������ģ�͵Ķ�����Ϣ�任������ռ��У�Ȼ��ͨ��һ��Draw call���ƶ��ģ�͡�\n" +
            "����: ��̬����ÿ֡�����һ����CPU������\n" +
            "���ó���: ��̬����ÿ֡�����һ����CPU������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GPU Instancing</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ԭ��: �ύһ��Mesh�ڶ���ط����ƣ�Ҫ���������ͬ�����ʵ����Կ��Բ�ͬ��\n" +
            "����: Shader��Ҫ֧�֡�Ҫ����Խϸ�ͼ��API�汾��Android OpenGL ES 3.0+ / IOS Metal����\n" +
            "���ó���: ������ͬ�����������Ⱦ��GPU Skinning��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowPredefinedMacros()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Target platform</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_D3D11</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Direct3D 11" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_GLCORE</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����� OpenGL�����ġ�(GL 3/4)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_GLES</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "OpenGL ES 2.0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_GLES3</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "OpenGL ES 3.0/3.1" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_METAL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "iOS/Mac Metal" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_VULKAN</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Vulkan" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_D3D11_9X</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ͨ�� Windows ƽ̨�� Direct3D 11�����ܼ���9.x��Ŀ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_PS4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "PlayStation 4��Ҳ������ SHADER_API_PSSL" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_XBOXONE</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Xbox One" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_MOBILE</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��������г����ƶ�ƽ̨ (GLES��GLES3��METAL) ����ġ�\n" +
            "���⣬��Ŀ����ɫ����ΪGLSLʱ�����ᶨ�� SHADER_TARGET_GLSL(����OpenGL/GLES ƽ̨��˵ʼ�ջᶨ��)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Shader target model(��ɫ��Ŀ��ģ��)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#if SHADER_TARGET < 30</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ӧ��#pragma target��ֵ,2.0����20,3.0����30" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Unity version</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#if UNITY_VERSION >= 500</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Unity�汾���жϣ�500��ʾ5.0.0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>platform difference helpers</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UV_STARTS_AT_TOP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "һ����жϵ�ǰƽ̨��DX(UVԭ�������Ͻ�)����OpenGL(UVԭ�������½�)\n" +
            "���������ж������Ƿ����� Direct3D ƽ̨�¡�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_NO_SCREENSPACE_SHADOWS</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����ƶ�ƽ̨������Cascaded ScreenSpace shadow." +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>UI</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UI_CLIP_RECT</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������������Rect Mask 2D���ʱ���\n" +
            "��Ҫ���ֶ�����˱���#pragma_multi_compile _UNITY_UI_CLIP_RECT��\n" +
            "ͬʱ��Ҫ����: _clipRect(һ����ά�������ĸ������ֱ��ʾRectMask2D�����½ǵ��xy���������Ͻǵ��xy����.)\n" +
            "UnityGet2DClipping (float2 position,foat4 clipRect)����ʵ�����á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UI_ALPHACLIP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_UI_ALPHACLIP��ָȷ�� UI Ԫ�������� UI Ԫ���ص�ʱ��γ��ֵ� alpha��͸���ȣ������á�\n" +
            " [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip (\"Use Alpha Clip\", Float) = 0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Lighting</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_SHOULD_SAMPLE_SH</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ƿ���м���SH (����̽���붥����ɫ)\n" +
            "����̬�붯̬Lightmap����ʱ��������\n" +
            "����̬�붯̬Lightmapû������ʱ������\n" +
            "��ForwardBase����Pass�������ÿPass��Ҫָ��UNITY_PASS_FORWARDADD��UNITY_PASS_SHADOWCASTER�ȡ�\n" +
            "�������������Ķ�̬&��̬������ͼ�����Ժ��Ե�������͹��� || Dynamic & Static lightmaps contain indirect diffuse ligthing, thus ignore SH\n" +
            "#define UNITY_SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_SAMPLE_FULL_SH_PER_PIXEL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ͼuv������SHL2�Ļ�����ɫ�ڶ���������ڲ����й���,�����þ�̬ihtmap��LIGHTPR OBESHʱ����������ɫ����ִ��������SH����\n" +
            "�˺��ʾ���ǽ���������ÿ����������͹��գ�������Ĭ�ϵ��𶥵����������͹��ղ������Բ�ֵ��ÿ�����С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">HANDLE_SHADOWS_BLENDING_IN_GI</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ͬʱ������SHADOWS_SCREEN��LIGHTMAP_ONͬʱ����\n" +
            "��HANDLE_SHADOWS_BLENDING_IN_GI����Ϊ1����������ȫ��������Ҳ����Ӱ���д���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADOW_COORDS(N)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����һ��foat4���͵ı��� shadowCoord,����Ϊ��N��TEXCOORD\n" +
            "SHADOW_COORDS,����������һ�����ڶ���Ӱ���������uv���ꡣһ������ƬԪ��ɫ��������ṹ���У����������Ĳ�����Ҫ����һ�����ò�ֵ�Ĵ���������ֵ��\n" +
            "TRANSFER_SHADOW,�����ǵõ�һ�����ڲ�����Ӱ��ͼ�����ꡣ\n" +
            "SHADOW_ATTENUATION,������ʹ��_SHADOWCOORD�Զ�Ӧ��������вɼ����õ���Ӱ��Ϣ��\n" +
            "���磺float attenuation = SHADOW_ATTENUATION(i)     ����    UNITY_LIGHT_ATTENUATION(attenuation, i, i.worldPos);" +
            "\r\nlight.color = _LightColor0.rgb * attenuation;\n" +
            "���ã��������ܹ�������Ӱ��ԭ���ǲ�����LightMode�� = ��ShadowCaster\" Pass����Ⱦ��������Ӱ���ͼ��Ȼ��������ںϣ���ӰԽǿ�ң���ͼ������ֵԽ����0\n" +
            "��Ҫ��Pass�а����µ������ļ� #include \"AutoLight.cginc\"" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">V2F_SHADOW_CASTER</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����LightMode��=��shadowCaster����,�൱�ڶ�����float4 pos:SV_POSITION.\n" +
            "����ʹ��SHADOWS_CUBE���Ҳ�ʹ��SHADOWS_CUBE_IN_DEPTH_TEXʱ,V2F_SHADOW_CASTER����float4 pos:SV_POTISION;float3 vec : TEXCOORD0;��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowPlatformDifferences()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�ü��ռ�</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">OpenGL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ü��ռ������귶Χ(-1,1)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">DirectX</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ü��ռ������귶Χ(1,0)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_NEAR_CLIP_VALUE</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ؼ��ռ��µĽ�����ֵ,(DXΪ1,OpenGLΪ-1)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�ü��ռ�</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">OpenGL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ü��ռ������귶Χ(-1,1)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Reversedz</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Reversed direction(������)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "DirectX 11��DirectX 12��PS4��Xbox one��Metal��Щƽ̨�����ڷ�����\n" +
            "���ֵ�ӽ��ü��浽Զ�ü����ֵΪ[1 ~ 0]��\n" +
            "�ؼ��ռ��µ�Z�᷶ΧΪ[near,0]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Traditional direction(��ͳ����)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����Ϸ������ƽ̨���ⶼ���ڴ�ͳ����\n" +
            "���ֵ�ӽ��ü��浽Զ�ü����ֵΪ[O~1]\n" +
            "�ü��ռ��µ�Z�᷶ΧΪ:\n" +
            "DXƽ̨=[0,far]           OpenGLƽ̨=[-near,far]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SystemInfo.usesReversedZBuffer</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����C#�жϵ�ǰƽ̨�Ƿ�֧��Reversedz��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowMath()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>������ѧ����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "#define UNITY_PI            3.14159265359f\n" +
            "#define UNITY_TWO_PI        6.28318530718f\n" +
            "#define UNITY_FOUR_PI       12.56637061436f\n" +
            "#define UNITY_INV_PI        0.31830988618f\n" +
            "#define UNITY_INV_TWO_PI    0.15915494309f\n" +
            "#define UNITY_INV_FOUR_PI   0.07957747155f\n" +
            "#define UNITY_HALF_PI       1.57079632679f\n" +
            "#define UNITY_INV_HALF_PI   0.636619772367f" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">max(a��b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ƚ�����������ȳ�����Ԫ�أ��������ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">min(a��b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ƚ�����������ȳ�����Ԫ�أ�������Сֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mul(M��V)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ʾ����M������V���е�ˣ�������Ƕ�����V����M����任���ֵ��\n" +
            "mul(M, v) = mul(v, transpose(M)), mul(v, M) = mul(transpose(M), v)\n" +
            "mul(M,N) ��������������ˣ����MΪAxB����NΪBxC�����򷵻�AxC����\n" +
            "transpose(M)       ����ת��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">abs(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ȡ����ֵ��xֵ������������\n" +
            "float abs(float a){    return    max(-a,a);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">round(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x���������ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sqrt(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x��ƽ������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">rsqrt(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x��ƽ����������ע��x����Ϊ0���൱��pow(x,-0.5)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">degrees(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��x�ӻ���ת���ɽǶȡ�\n" +
            "float degrees(float x){    return    57.29577951 * x;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">redians(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���Ƕ�ת��Ϊ���ȡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">noise(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������������uv������Ϊ����x���룬���ص�0-1֮������ֵ��\n" +
            "PS: ����ͬ�������룬������ͬ��ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��ָ�Ժ�����ƫ����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">pow(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x��y���ݡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">exp(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������eΪ�׵�ָ��������e��x�η���      e = 2.71828182845904523536" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">exp2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������2Ϊ�ף�xΪָ�����ݡ�2��x�η���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ldexp(x,exp)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x��2��exp�η��ĳ˻���x(2^n)��ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ָ��ֵ����eΪ�����Ķ�����ln(x)��ֵ��x�������0��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������2Ϊ�����Ķ�����log2^x��ֵ��x�������0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log10(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������10Ϊ�����Ķ�����log10^x��ֵ��x�������0��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddx(a)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����a��Ӧһ������λ�ã����ظ�����ֵ��X���ƫ������\n" +
            "ddx(a) = �����ص��ұߵ�aֵ - �����ص��aֵ" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddy(a)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����a��Ӧһ������λ�ã����ظ�����ֵ��y���ƫ������\n" +
            "ddx(a) = �����ص������aֵ - �����ص��aֵ" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddx��ddy</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ι�դ���ǣ�GPU ������ 2x2 �� block Ƭ���������դ���ġ�\n" +
            "��ô�����2x2���ؿ鵱�У��Ҳ�����ض�Ӧ��fragment��x�����ȥ�������ض�Ӧ��fragment��x�������ddx���²����ض�Ӧ��fragment������y��ȥ�ϲ����ض�Ӧ��fragment������y����ddy��\n" +
            "��Եͻ��: ԭ�����ddx��ddy�ֱ��ÿ�����ض�x��y����ƫ�������õ��仯�ʣ��仯�ʸߵĵط������豸��Ȳ�����Ǳ�Ե��\n" +
            "ƫ����ddx/y���Լ�������FragmentShader������ı���������������ȵȡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���Ǻ�����˫���ߺ���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sin(x)��cos(x)��tan(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "sin(x) �������Ϊ���ȣ���������ֵ������ֵ��Χ[-1,1];\n" +
            "cos(x) ����x������ֵ������ֵ��Χ[-1,1];\n" +
            "tan(x)�������Ϊ���ȣ���������ֵ��\n" +
            "���Ǻ����������ƣ�1��=��/180 rad��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">asin(x)��acos(x)��atan(x)��atan2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "asin(x) �����Һ���������Ĳ���ȡֵ����[-1,1],���ؽǶ�ֵ��ΧΪ[-��/2,��/2];\n" +
            "acos(x) �����Һ��������������Χ[-1,1],����[0,��]����ĽǶ�ֵ;\n" +
            "atan(x) �����к��������ؽǶ�ֵ��Χ[-��/2,��/2];\n" +
            "atan2(y,x) ����y/x�ķ�����ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sinh(x)��cosh(x)��tanh(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "˫���ߺ���:     x^2-y^2=1\n" +
            "sinh(x) ����x��˫������ֵ����0.5*(ex-e-x);\n" +
            "cosh(x) ����x��˫�����Һ�������0.5*(ex-e-x);\n" +
            "tanh(x) ����x��˫������ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sincos(float x ,out s, out c)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ú�����ͬʱ����x��sinֵ��cosֵ������s=sin(x),c=cos(x),�����ȷֿ�����Ҫ�졣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���ݷ�Χ</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ceil(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ȡ��������>=x����С������\n" +
            "float ceil(float x){    return    -floor(-x);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">floor(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ȡ��������<=x�����������(ȥβ����)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">step(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x<=y����1�����򷵻�0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">saturate(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���xС��0������0�����x����1������1�����򷵻�x;\n" +
            "���ؽ�xǯ�Ƶ�[0,1]��Χ֮���ֵ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">clamp(x,min,max)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���xС��a������a��x����b���򷵻�b�����򣬷���x;\n" +
            "��x������[min��max]��Χ��ֵ����minС����min����max�󷵻�max" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fmod(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x��yȡ���������\n" +
            "x/y�����������yΪ0���������Ԥ��;\n" +
            "float fmod(float x,float y){    float c = frac(abs(a/b) * abs(b);    return   (a<0) ? -c : c;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">frac(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ȡx��С�����֡�\n" +
            "���ر���������ÿ����������ķ������֡�\n" +
            "float frac(float x){    return    x - floor(x);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">modf(x,out ip)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��x��ΪС������������(�����ipΪ�������֣�����ֵΪС������)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">lerp(x,y,s)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "s��x��y֮���ֵ��\n" +
            "���s = 0,����x;   ���s = 1,����y;\n" +
            "���򷵻�x��y�Ļ��ֵ;  x + s*(y-x)����(1-s)*x + y*s\n" +
            "PS:���x��y����������Ȩֵs�����Ǳ������ߵȳ���������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">smoothstep(min,max,x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x��[min��max]��Χ�ڣ��ͷ��ؽ���[0��1]֮���ƽ����ֵ��\n" +
            "��x=min,����0����x=max,����1����x������֮�䣬�����й�ʽ��������(��0��1֮��)��\n" +
            "-2((x-min)/(max-min))^3+3*((x-min)/(max-min))^2;\n" +
            "���ֻ����Ҫ���Թ��ɣ�����Ҫƽ����ֱ��ʹ��saturate((x-min)/(max-min))��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�����ж���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">all(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ȷ��ָ���������з����Ƿ��Ϊ���㣬�������򷵻�true�����򷵻�false\n" +
            "(�����ɸ����͡����͡����������ݶ���ı������������߾���)��\n" +
            "bool all(float4 x){    return    a.x && a.y && a.z && a.w;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">any(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����Ĳ���ֻҪ��һ����Ϊ0���򷵻�true��\n" +
            "bool any(float4 x){    return    a.x || a.y || a.z || a.w;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">clip(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ֵС���㣬������ǰ���� �������ж���Χ(���������0,����ֵΪvoid)��\n" +
            "������Alpha Test�����ÿ����������ƽ��ľ��룬����������ģ�����ƽ�档\n" +
            "void clip(float4 x){    if(any(x<0))   discard;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sign(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����x�������ԡ�\n" +
            "���x<0,����-1     ���x=��,����0     ���x>��,����1" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isinf(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���x����Ϊ+ INF��-INF(����+���������0x3f3f3f3f)������true�����򷵻�False��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isfinite(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�жϱ������������е�ÿ�������Ƿ������ޣ�����Ƿ���true�����򷵻�false����isinf(x)�෴��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isnan(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�жϱ������������е�ÿ�������Ƿ��Ƿ����ݣ�����Ƿ���true�����򷵻�false\n" +
            "���x����ΪNAN(������)������true�����򷵻�false��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>�����;�����</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">length(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������ĳ��ȣ�����һ��������ģ����sqrt(dot(v,v))" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">normalize(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������һ����x/length(x) ����������һ��(����һ��������ģΪ1)��\n" +
            "normalize(x) = rsqrt(dot(x,x))*x" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">distance(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������������֮��ľ��룬��ƽ�е���������Ӧ��Ϊ0���˴���ʾΪ�����¸�����֮���ƽ���͡�\n" +
            "��������֮���ŷ����þ��롣\n" +
            "float distance(a,b){     float v = b-a;      return  sqrt(dot(v,v));    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">dot(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������a��b�����������ı��/�ڻ�/������/���(a��b�ϵ�ͶӰ����a��b=|a||b|��cos��)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">cross(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���������a��b������������ʸ��/���/������/���(����ֵ�Ǹ�������������a��b����ֱ,��С��| a x b | = |a| * |b| * sin��)\n" +
            "float cross(float3 a,float3 b){     return  a.yzx * b.zxy - a.zxy * b.yzx;    } " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">determinant(m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ָ���������İ�����ʽ��ʽ�����ֵ�����������ʽ���ӡ�(ֻ�з����������ʽ)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">transpose(m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ؾ���m��ת�þ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����������</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">reflect(i,n)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��iΪ��������nΪ���߷���ķ���⡣\n" +
            "PS: ����i��n���뱻��һ������Ҫע����ǣ����i��ָ�򶥵�ģ�����ֻ����Ԫ������Ч��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">refract(i,n,ri)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��iΪ��������nΪ���߷���,riΪ�����ʵ�����⡣\n" +
            "PS: ����i��n���뱻��һ�������i��n֮��н�̫���򷵻�(0,0,0),Ҳ����û��������ߣ�����ֻ����Ԫ������Ч��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">lit(NdotL,NdotH,m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "N��ʾ��������L��ʾ�����������H��ʾ���������m��ʾ�߹�������\n" +
            "�������㻷���⣬ɢ��⣬�����Ĺ��ף�������Ԫ������\n" +
            "X��ʾ������Ĺ��ף�����1��Y��ʾɢ���Ĺ��ף����N.L<0,��Ϊ0������ΪN.L; Z��ʾ�����Ĺ��ף�\n" +
            "���N.L<0����N.H<0����Ϊ0������Ϊ(N.H)^m;Wʼ��Ϊ1��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">faceforword(N,I,Ng)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ng*I<0,����N�����򷵻�-N��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����ӳ�亯��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">һά�������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GPU��PS�׶�������Ļ�ռ�XY����ϵ�ж�ÿһ������ȥ��Ӧ�������в��Ҷ�Ӧ��������ȷ�����ص���ɫ;\n" +
            "tex1D(sampler1D tex,float s)  һά�����ѯ;\n" +
            "tex1D(sampler1D tex, float s, float dsdx, float dsdy) ʹ�õ���ֵ��ѯһά����;\n" +
            "Tex1D(sampler1D tex, float2 sz) һά�����ѯ�����������ֵ�Ƚ�;\n" +
            "Tex1D(sampler1D tex, float2 sz, float dsdx,float dsdy) ʹ�õ���ֵ��derivatives����ѯһά���� ���������ֵ�Ƚ�;\n" +
            "Tex1Dproj(sampler1D tex, float2 sq) һάͶӰ�����ѯ;\n" +
            "Tex1Dproj(sampler1D tex, float3 szq) һάͶӰ�����ѯ�����Ƚ����ֵ;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2D�������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Tex2D(sampler2D tex, float2 s)  ��ά�����ѯ;\n" +
            "Tex2D(sampler2D tex, float2 s, float2 dsdx, float2 dsdy) ʹ�õ���ֵ�� derivatives ����ѯ��ά����;\n" +
            "Tex2D(sampler2D tex, float3 sz) ��ά�����ѯ�����������ֵ�Ƚ�;\n" +
            "Tex2D(sampler2D tex, float3 sz, float2 dsdx,float2 dsdy) ʹ�õ���ֵ�� derivatives ����ѯ��ά�������������ֵ�Ƚ�;\n" +
            "Tex2Dproj(sampler2D tex, float3 sq) ��άͶӰ�����ѯ;\n" +
            "Tex2Dproj(sampler2D tex, float4 szq) ��άͶӰ�����ѯ�����������ֵ�Ƚϡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2D�������(OpenGL����)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "texRECT(samplerRECT tex, float2 s) ��ά��ͶӰ���������ѯ;\n" +
            "texRECT (samplerRECT tex, float3 sz, float2 dsdx,float2 dsdy) ��ά��ͶӰʹ�õ����ľ��������ѯ;\n" +
            "texRECT (samplerRECT tex, float3 sz) ��ά��ͶӰ��ȱȽϾ��������ѯ;\n" +
            "texRECT (samplerRECT tex, float3 sz, float2 dsdx,float2 dsdy) ��ά��ͶӰ��ȱȽϲ�ʹ�õ����ľ��������ѯ;\n" +
            "texRECT proj(samplerRECT tex, float3 sq) ��άͶӰ���������ѯ;\n" +
            "texRECT proj(samplerRECT tex, float3 szq) ��άͶӰ����������ȱȽϲ�ѯ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�����������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Tex3D(sampler3D tex, float s) ��ά�����ѯ;\n" +
            "Tex3D(sampler3D tex, float3 s, float3 dsdx, float3 dsdy) ��ϵ���ֵ��derivatives����ѯ��ά����;\n" +
            "Tex3Dproj(sampler3D tex, float4 szq) ��ѯ��άͶӰ�������������ֵ�Ƚ�;\n" +
            "texCUBE(samplerCUBE tex, float3 s) ��ѯ����������;\n" +
            "texCUBE (samplerCUBE tex, float3 s, float3 dsdx, float3 dsdy) ��ϵ���ֵ��derivatives����ѯ����������;\n" +
            "texCUBEproj (samplerCUBE tex, float4 sq) ��ѯͶӰ����������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���Ժ���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">void debug(float4 x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����ڱ���ʱ������ DEBUG ��Ƭ����ɫ�����е��øú������Խ�ֵ x ��Ϊ COLOR ������������������ú���ʲôҲ������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��Ⱦָ��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">D3D��ɫ������ʹ�õ�ָ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "DXBCָ����D3D��ɫ������ʹ�õ�ָ�HLSL�߼���ɫ���Ծ�������������֮�󣬻�������Ӧ��DXBCָ�\n" +
            "DXBCָ��������ΪGPU��Ҫ����ִ�е�ָ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mov dest, src</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ĵ�����ֵָ����dest��һ�������Ĵ�������src.wȡ����ֵ��dest������dest = src��\n" +
            "dest��Ŀ��Ĵ�����src��Դ�Ĵ���������Դ�Ĵ�����Ŀ��Ĵ������ƶ����ݡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mova a0, src </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������Ĵ���src��ֵȡ����ֵ����ַ�Ĵ���a0��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">add dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�� src0���� + src1���� ������dest�С�\n" +
            "src0 ��Դ�Ĵ�����src1 ��Դ�Ĵ�����������dest.x = src0.x + src1.x ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">abs dest, src</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��src���������ֵ������dest�С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mul dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�� ����src0������src1 ��� ������dest�С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">div dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�� ����src0������src1 ��� ������dest�С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mad dest, src0, src1��src2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�˼�ָ�dest = src0 * src1 + src2��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">dp2 dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ָ�dest= src0.x * src1.x + src0.y * src1.y��\n" +
            "dp3: dest= src0.x * src1.x + src0.y * src1.y + src0.z * src1.z\n" +
            "dp4: dest= src0.x * src1.x + src0.y * src1.y + src0.z * src1.z + src0.w * src1.w" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">rsq dest, src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "rsqrt(src1)����src0����ƽ�����ĵ�����������dest�С�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale); 
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sqrt dest, src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ƽ��������ʽΪdest = sqrt(src0)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale); 
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">add dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "add���ڼӷ����㣬destΪ�洢����ı�����src0�Լ�src1 Ϊ��������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">discard src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�������ı��������ɫ�����������\n" +
            "����discard_nz��ʾ��Ϊ0ʱ��������discard_z��ʾΪ0ʱ��������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowLighting()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����NormalMap</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ԭ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ߴ������������е�(world space)���ǳ�Ϊworld space normal������Ǵ������屾��ֲ������еģ��ǳ�Ϊobject space normal��\n" +
            "���߱��洢�����߿ռ䣨Tangent Space Normal���У����߿ռ��Ե�ķ��߷���ΪZ�ᣬ��Ӧ��RGB�е�Bֵ�����Է�����ͼ����ȥ����ɫ�ġ�����洢������ռ��У�������������ֳ���ͬ����ɫֵ��\n" +
            "Ŀ��: Ϊ������ģ�ͱ���ϸ�ڶ��ֲ������������ģ����Բ�ѡ�����ģ�͵����������Ǹ�ģ�͵Ĳ���Shader��ʹ���Ϸ�����ͼ��\n" +
            "Normal Maps��������ͼ����Height Maps���߶���ͼ����������Bump Map����͹��ͼ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>����ģ��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Lambertian(������������)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�����������䣨Lambertian Diffuse���Ĺ���ǿ�ȣ�ȡ���ڹ���������������淨������������Ҽнǡ�\n" +
            "Diffuse = Ambient + Kd * LightColor * max(0,dot(N,L))\n" +
            "Diffuse:���������ϵ��������ǿ\n" +
            "Ambient:������ǿ�ȣ�Ϊ�˼򻯼��㣬������ǿ����һ��������ʾ\n" +
            "Kd:������ʶԹ�ķ���ϵ��\n" +
            "LightColor: ��Դ��ǿ��\n" +
            "N:����ĵ�λ��������\n" +
            "L:����ָ���Դ�ĵ�λ����\n\n" +
            "C(diffuse) = C��(color)C��(color)( n(��������) �� l(��Դ����) )\n" +
            "// ��ӻ�����\n" +
            "fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;\n" +
            "// ���緽���\n" +
            "fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);\n" +
            "fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLight));\n" +
            "//��������������ǿ�ȼ���\n" +
            "half diffuseStrength = saturate(dot(i.worldNormal, i.worldLightDir) * 0.5 + 0.5);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Phong(�߹ⷴ��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Phong����ģ����һ�������������߹�Ĺ���ģ�ͣ��߹��ǿ�Ⱥͷ�Χȡ���ڹ�Դ�������ķ���͹۲����������ķ���\n" +
            "Specular = SpecularColor * Ks * pow(max(0,dot(R,V))��Shininess)\n" +
            "Specular:���������ϵķ���߹��ǿ\n" +
            "SpecularColor:��������ɫ\n" +
            "Ks:����ǿ��ϵ����\n" +
            "R:������������ʹ��2* N* dot(N,L)- L����refect (-L,N)���\n" +
            "V:�۲췽��\n" +
            "N:����ĵ�λ��������\n" +
            "L:����ָ���Դ�ĵ�λ����\n" +
            "Shininess:�˷�������ģ��߹�ı仯\n\n" +
            "Phong�߹ⷴ����ɫ = �������ɫ X �߹ⷴ����ɫ X max(0,Dot(�ӽǷ��򣬷��䷽��))^����ϵ����\n" +
            "C(diffuse) = C��(color)C��(color)( (2 (n(��������) �� l(��Դ����)) n(��������) - l(��Դ����) ) �� v(��Դ����) )^mgless\n" +
            "// �߹ⷴ�䵥λ������r������\n" +
            "fixed3 reflectDir = normalize(reflect(-worldLightDir, i.worldNormal));\n" +
            "// �����嵽������ĵ�λ������v������\n" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(reflectDir,view)),_Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blinn-Phong(�߹ⷴ��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ӵ�����������Phong-Blinn������ Phong�������ظ߹ⷴ��ı��֡���Ϊ���ı�������ƬԪ��ɫ���Ĳ��ִ��롣\n" +
            "Specular = SpecularColor * Ks * pow(max(0,dot(R,H))��Shininess)\n" +
            "Specular:���������ϵķ���߹��ǿ\n" +
            "SpecularColor:��������ɫ\n" +
            "Ks:����ǿ��ϵ����\n" +
            "R:������������ʹ��2* N* dot(N,L)- L����refect (-L,N)���\n" +
            "H:�������L������V���м�������Ҳ��Ϊ�������H = normalize(L+V)\n" +
            "N:����ĵ�λ��������\n" +
            "L:����ָ���Դ�ĵ�λ����\n" +
            "Shininess:�˷�������ģ��߹�ı仯\n\n" +
            "ֱ��� Specular = ֱ��� * pow( max(cos��,0),10)  ��:�Ƿ��ߺ�x�ļн�  x ��ƽ�й����Ұ�����ƽ���ߡ�\n" +
            "C(Blinn-Phong-diffuse) = (C��(color)C��(color)) (n(��������) �� h(��Դ�������������ƽ����λ����))^mgless\n" +
            "// �����嵽������ĵ�λ����" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));" +
            "// ��Դ�������������ƽ����λ������h������\n" +
            "fixed3 halfDir = normalize(worldLightDir + viewDir);\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(i.worldNormal, halfDir)), _Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Disney Principled BRDF(��ʿ�����ģ��)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ӵ�����������Phong-Blinn������ Phong�������ظ߹ⷴ��ı��֡���Ϊ���ı�������ƬԪ��ɫ���Ĳ��ִ��롣\n" +
            "f(l,v) = diffuse + D(��h)F(��d)G(l,v,h)/4cos(��1)cos(��v)\n" +
            "f(l.v):˫����ֲ�����������ֵ,l��ʾ��ķ���,v��ʾ���ߵķ���\n" +
            "diffuse:������\n" +
            "D(h):���߷ֲ�����(Normal Distribution Function)����΢��Ԫ���߷ֲ��ĸ���,��������ȷ�ķ���Ũ��,hΪ�������,��ʾ��ķ����뷴�䷽��İ������,ֻ�������΢���淨��m=hʱ,�Żᷴ�䵽�����У�\n" +
            "D(h)= roughness^2 /n((n��h)2(roughness^2-1)+1)^2\n" +
            "F(v.h):����������(Fresnel Equation),������ͬ�ı�����±���������Ĺ�����ռ�ı���\n" +
            "F(v,h) = FO +(1-F0)(1-(v��h))^5(FO��0������ǵķ���������ֵ)\n" +
            "G(l,v,h): G(l,v,h) = G(��l)G(��v)���κ���(Geometry Function),����΢ƽ���Գ���Ӱ������,��΢���淨��m = h�Ĳ�δ���ڱεı����İٷֱȣ�\n" +
            "4cos(n��I)cos(n��v):У������(correctionfactor)��Ϊ΢�ۼ��εľֲ��ռ��������۱���ľֲ��ռ�֮��任��΢ƽ������У��\n\n" +
            "ֱ��� Specular = ֱ��� * pow( max(cos��,0),10)  ��:�Ƿ��ߺ�x�ļн�  x ��ƽ�й����Ұ�����ƽ���ߡ�\n" +
            "C(Blinn-Phong-diffuse) = (C��(color)C��(color)) (n(��������) �� h(��Դ�������������ƽ����λ����))^mgless\n" +
            "// �����嵽������ĵ�λ����" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));" +
            "// ��Դ�������������ƽ����λ������h������\n" +
            "fixed3 halfDir = normalize(worldLightDir + viewDir);\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(i.worldNormal, halfDir)), _Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>shadowMap��Ӱ</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������Ӱ</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.���\"LightMode\"=\"ShadowCaster\"��Pass��\n" +
            "2.appdata������float4 vertex;POSITION;��half3 normal:NORMAL;����������Ӱ����Ҫ�����塣\n" +
            "3.v2f����V2F_SHADOW_CASTER;����������Ҫ���͵�ƬԪ�����ݡ�\n" +
            "4.�ڶ�����ɫ������ TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)��֧�ַ���ƫ����Ӱ����Ҫ�Ǽ�����Ӱ��ƫ���Ծ�����ȷ��Shadow Acne��Petel-Panning����\n" +
            "5.��ƬԪ��ɫ������ SHADOW_CASTER_FRAGMENT(i)\n" +
            "// ��Ӱ�Ķ�Ӧ�ꡣֻ��ʹ����������ָ��ſ�������ص�pass�еõ���Ӱ������\n" +
            "#pragma multi_compile_shadowcaster" +
            "// ����������ɫ����ʵ������Ӱ���̣����κ�һ������Ͷ����Ӱ�ĵط�Ͷ����Ӱ��\n" +
            "#pragma multi_compile_instancing " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������Ӱ</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.��v2f�����SHADOW_COORDS(3),unity���Զ�����һ����ShadowCoord��foat4������������Ӱ�Ĳ������ꡣ��3��ָ����TEXCOORD��3��\n" +
            "2.�ڶ�����ɫ����TRANSFER_SHADOW(o)�����ڽ����涨���_ShadowCord�����������任����Ӧ����Ļ�ռ��������꣬Ϊ������Ӱ����ʹ�á�\n" +
            "3.��ƬԪ��ɫ�� " +
            "// ���ЭSHADOW_COORDSͬ�������õ���Ӱֵ\n" +
            "fixed shadow = SHADOW_ATTENUATION(i);\n" +
            "// ���ЭSHADOW_COORDSͬ�����������˹���˥���Լ���Ӱ��������ForwardBase�����ع�Դһ���Ƿ���⣬˥���̶�Ϊ1����˴�ʱ˥�������壬����ʽ��ͬ��" +
            "UNITY_LIGHT_ATTENUATION(shadow,i,i,worldPos);      ����shadow���洢�˲��������Ӱ��\n" +
            "return fixed4((diffuse + specular) * shadow + i.vertexLight, 1);\n" +
            "// ֻ��ʹ����������ָ��ſ�������ص�pass�еõ�������Դ�Ĺ��ձ������������˥��ֵ�ȡ�\n" +
            "#pragma multi_compile_fwdbase" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>ȫ�ֹ���Global Illumination��GI��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ȫ�ֹ���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ȫ�ֹ������ھֲ����յĻ����ϣ����ӿ�������������֮����߽���������˵����ֲ�����ϵͳ�����ɹ�Դ+����Ⱦ����+�ӵ���ɵĻ�����ôȫ�ֹ���ϵͳ�����ɹ�Դ+������Ⱦ����֮��ķ����+����Ⱦ����+�ӵ���ɡ�\n" +
            "���û��ȫ�ֹ��ռ�������Щ�Է���ı��沢�������������Χ�����壬�������������������˶��ѡ�\n" +
            "color = FragmentGI + UNITY_BRDF_PBS +Emission\n" +
            "��ӹ���:���\"LightMode\"=\"Meta\"��Pass���ɲο�����shader�е�Meta Pass" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Light Probe����̽��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����̽��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Light Probe������ռ���һ���Irradiance��Ȼ�󱣴浽3����г�����С���������ʱ����г�����и�ԭ�����źţ��������µ���ȷ��Irradiance��\n" +
            "����1:��������ƽ�еƱ��ΪMixedʱ,ͬʱ��������LightProbeʱ,��ô��ǰƽ�еƵĹ���ֵ���Զ���LightProbeӰ��,���Բ�������Shader���Ƿ���SH��ص�����,�����ܵ�LightProbe��Ӱ��\n" +
            "����2:��������ƽ�еƱ��ΪBakedʱ,ͬʱ��������LightProbeʱ,��ô��Ҫ����������Shader����SH��ص�����,�Ż��ܵ�LightProbe��Ӱ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Reflection Probe����̽��</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����̽��Ĳ���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����̽�е�ǰ�����CubeMap�洢��unity_SpecCube0���У�����Ҫ��UNITY_SAMPLE_TEXCUBE���в�����Ȼ����Ҫ������н��롣\n" +
            "half3 worldView = normalize(UnityWorldSpaceViewDir(i.worldPos));\n" +
            "half3 R = reflect (-worldView��N);\n" +
            "half4 cubemap =UNITY_SAMPLE_TEXCUBE(unity_SpecCube0,R):\n" +
            "half3 skyColor = DecodeHDR(cubemap,unity_SpecCube0_HDR);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Fog ��Ч</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_FogColor</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������Ч����ɫ��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����һ:</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.#pragma multi_compile_fog������Ч����Ҫ�����ñ���:FOG_LINEAR FOG_EXP FOG_EXP2��\n" +
            "2.UNITY_FOG_COORDS(i): �������㴫��ƬԪ����Ч��ֵ��(fogCoord)\n" +
            "3.UNITY_TRANSFER_FOG(o,o.vertex): �ڶ�����ɫ���м�����Ч����\n" +
            "4.UNITY_APPLY_FOG(i.fogCoord��col): ��ƬԪ��ɫ���н�����Ч��ɫ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������:</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "����v2f���ж���worldPosʱ�����԰�worldPos.w����������Ϊ��Чֵ��\n" +
            "1.#pragma multi_compile_fog������Ч����Ҫ�����ñ���:FOG_LINEAR FOG_EXP FOG_EXP2��\n" +
            "2.UNITY_TRANSFER_FOG_COMBINED_WITH_WORLD_POS(o,o.worldPos)���������굽������ɫ��\n" +
            "�ڶ�����ɫ������ӣ�o.worldPos��ʾ����ռ��µĶ�������\n" +
            "3.UNITY_EXTRACT_FOG_FROM_WORLD_POS(): ��ƬԪ��ɫ�������\n" +
            "4.UNITY_APPLY_FOG(_unity_fogCoord,c): ��ƬԪ��ɫ���н�����Ч��ɫ���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowMiscellaneous()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>UV</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UV��ӳ�䵽����λ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = uv * 2 - 1;\n" +
            "��UVֵ��ӳ��Ϊ(-1,-1)~(1,1)��Ҳ���ǽ�UV�����ĵ�����½��ƶ����м�λ�á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��Բ</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float circle = smoothstep(_Radius,(_Radius + _CircleFade), length(uv * 2 - 1));\n" +
            "����UV����Բ��ͨ��_Radius�����ڴ�С��_CircleFade�����ڱ�Ե�黯����" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = abs(i.uv.xy * 2 - 1);\n" +
            "float rectangleX = smoothstep(_Width, ( _Width + _RectangleFade), centerUV.x);\n" +
            "float rectangleY = smoothstep( Heigth, ( _Heigth + RectangleFade), centerUV.y);\n" +
            "float rectangleClamp = clamp((rectangleX + rectangleY)��0.0,1.0);" +
            "����UV�������Σ�_Width���ڿ�ȣ�_Height���ڸ߶ȣ�_RectangleFade���ڱ�Ե�黯�ȡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">�ڰ����̸�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 uv =i.uy;\n" +
            "uv = foor(uv)* 0.5;\n" +
            "float c = frac(uv.x + uv.y) * 2;\n" +
            "return c;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = (i.uy * 2 - 1);\n" +
            "float atan2UV = 1 - abs(atan2(centerUV.g, centerUV.r) / 3.14);\n" +
            "����UV��ʵ�ּ����ꡣ" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��0-1��ֵ������ĳ���Զ����������</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "frac(x*n+n);\n" +
            "����frac(i.uv*3.33+3,33);���ǽ�0-1��uvֵ���¶���Ϊ0.33-0.66;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.frac(sin(dot(i.uv.xy��foat2(12.9898��78.233)))* 43758.5453);\n" +
            "2.frac(sin(x)*n);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">��ת</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "fixed t= Time.y;\n" +
            "float2 rot= cos(t)*i.uv+sin(t)*float2(i.uv.y , -i.uv.x);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����ͼ</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "spitUV�ǰ�ԭ�е�UV���¶�λ�����Ͻǵĵ�һ��UV�ϣ�_Sequence.xy��ʾ�����������ɼ�x���ĸ�����ɵ�,_Sequence.z��ʾ���������еĿ���\n" +
            "float2 splitUV = uv * (1/_Sequence.xy) + float2(0,_Sequence.y - 1/_Sequence.y);\n" +
            "float time =_Time.y * _Sequence.z;" +
            "uv = splitUV + float2(floor(time *_Sequence.x)/_Sequence.x,1-floor(time)/_Sequence.y);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowErrorDebug()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��������</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Did not find shader kernel 'frag'to compile at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�Ҳ���ƬԪ��ɫ����������Ƿ�����ȷ��дƬԪ��ɫ��fragment��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">syntax error : unexpected token ')at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��һ�д����﷨����,��������Ƿ�����ʲô�����û�п�������ǰһ���Ƿ��������ķֺš�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">cannot implicitly convert from 'float2' to 'half4' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "������ʽ�Ľ�foat2ת����foat4,��Ҫ�ֶ���ȫ��ʹ�Ⱥ����߷�������һ���ſ��ԡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">invalid subscript 'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ч���±꣬ͨ������Ϊxx�����ڻ���xx�ķ��������ڵ��µġ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">undeclared identifier'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xxδ���塣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unrecognized identifier 'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xxδʶ�𵽡�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">'xx':no matching 2 parameter intrinsic function</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ͨ������ΪXX�������������ڵĲ�����ƥ��(������������)��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">redefinition of 'xx' at xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xx���ظ������ˣ������Ƿ�����õ�hlsl����cginc�е��ظ��ˡ�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">comma expression used where a vector constructor may have been intended at line 48 (on d3d11)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "���ŵ�ʹ�ó������ԣ�����float4 a = (0��0��0��1);Ӧ��д��float4 a = foat4(0,0,0,1);��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowWWW()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>��ҳ�Ƽ�</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.SelectableLabel("<size="+titleScale+">Shader�ο�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
             "https://www.shadertoy.com/" +
             "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">glsl�ο�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "https://glslsandbox.com/" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">Shader�ο�2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://editor.isf.video/shaders?q=&category=&sort=Popularity+%E2%86%93&page=0" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">��ѧ��ʽ</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "https://graphtoy.com/" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">��ʽת��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://tool.4xseo.com/" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">DXBCָ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "http://xiaopengyou.fun/public/2021/01/16/DXBC%E6%8C%87%E4%BB%A4/" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">��ʿ�����ģ��</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://www.jianshu.com/p/f92c9037355e" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">��Ӱ�����ܽ�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://zhuanlan.zhihu.com/p/574687894?utm_id=0" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">unity-shader�����ţ�</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://blog.csdn.net/qq_50682713/article/details/117993486" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">unity-shader���м���</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
          "https://blog.csdn.net/qq_50682713/article/details/125758881?spm=1001.2014.3001.5502" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+ ">��Ŀ�ο�</size><color=red>       ǿ���Ƽ�</color>\n<color=#" + descColorStr+"><size="+descScale+">" +
          "https://github.com/csdjk/LearnUnityShader" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">UI��Ч</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
          "https://github.com/mob-sakai/UIEffect" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">ShaderLab ����ʵս</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
         "https://shenjun4shader.github.io/shaderhtml/" +
         "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">The Book of Shaders</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
         "https://thebookofshaders.com/?lan=ch" +
         "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
    }

    void ShowSetup()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        titleColor = EditorGUILayout.ColorField("���ֱ�����ɫ��", titleColor);
        titleStr = ColorUtility.ToHtmlStringRGB(titleColor);
        descColor = EditorGUILayout.ColorField("����������ɫ��", descColor);
        descColorStr = ColorUtility.ToHtmlStringRGB(descColor);
        bgColor = EditorGUILayout.ColorField("������ɫ��", bgColor);
        bgStr = ColorUtility.ToHtmlStringRGB(bgColor);
        
        titleScale = (int)EditorGUILayout.Slider("���ֱ����С��", titleScale,20,50);
        titleScale = Mathf.Clamp(titleScale, 20, 50);

        descScale = (int)EditorGUILayout.Slider("�������ݴ�С��", descScale,15, 25);
        descScale = Mathf.Clamp(descScale, 15, 25);

        interspaceScale = (int)EditorGUILayout.Slider("�����С��", interspaceScale, 4, 12);
        interspaceScale = Mathf.Clamp(interspaceScale, 4, 12);

        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">����1</size>\n<color=#" + descColorStr + "><size="+descScale+">" +
            "����1" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size=" + titleScale + ">����2</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "����2" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        // �������水ť
        if (GUILayout.Button("����"))
        {
            // �ڰ�ť�����ʱִ�б����߼�
            SaveParameters();
            EditorUtility.DisplayDialog("����ɹ�", "��������ɹ���", "ȷ��");
        }
    }

    void SaveParameters()
    {
        EditorPrefs.SetInt("TitleScale", titleScale);
        EditorPrefs.SetInt("DescScale", descScale);
        EditorPrefs.SetInt("InterspaceScale", interspaceScale);

        EditorPrefs.SetString("TitleStr", titleStr);
        EditorPrefs.SetString("DescColorStr", descColorStr);
        EditorPrefs.SetString("BgStr", bgStr);
    }

    void GetParameters()
    {
        titleScale = EditorPrefs.GetInt("IntValue", titleScale);
        descScale = EditorPrefs.GetInt("DescScale", descScale);
        interspaceScale = EditorPrefs.GetInt("InterspaceScale", interspaceScale);

        titleStr = EditorPrefs.GetString("TitleStr", titleStr);
        ColorUtility.TryParseHtmlString("#" + titleStr, out titleColor);
        descColorStr = EditorPrefs.GetString("DescColorStr", descColorStr);
        ColorUtility.TryParseHtmlString("#" + descColorStr, out descColor);
        bgStr = EditorPrefs.GetString("BgStr", bgStr);
        ColorUtility.TryParseHtmlString("#" + bgStr, out bgColor);
    }

    void ShowAnnouncement()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        //����
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>���ٱ��������ķ���</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "�ڴ���ShaderLab�Ĵ�С�ͱ�������ȹ�ϵ���Ӽ����ڴ淽��Ӧ�þ������ٱ�������������ʹ�� #pragma skip_variants��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��ʹ��ShaderVariantCollection�ռ�������ʱ��ֻ��shader_feature����ĺ������壬multi_compile�ı��岻���ռ�Ҳ�ᱻȫ��������塣" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">3</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "2018.2�¹���OnProcessShader�����Ƴ����õ�shader���塣��#pragma skip_variants������" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "��Ŀǰ�ڽ�������Ч���������̣��淶shader�궨��ʹ�ã���ֹTAΪ������Ч������ʹ�ú궨���������Թ�����Ŀ���������������ڽ��д�������µ���Դ�˷ѷǳ�֮��" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">5</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ShaderLab�����shader�����ڴ�ʱ���Ѿ������������û�б���Ⱦ�Ļ����ᴥ��CreateGPUProgram�����������ǰ��ShaderVariantCollection���ռ�����ر��岢ִ����warmup�Ļ���\n" +
            "��һ����Ⱦʱ�Ͳ�����CreateGPUProgram���Կ��ٻ���һ���ô���" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowAbout()
    {
        //����ͨ��
        GUIStyle contentStyle = GetGUIStyle();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size=" + titleScale + ">���ߣ���ë</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "�����κ����⣬�����и��õ���վ�Ƽ����Ը��ҷ��ʼ���\n" +
            "��ѧ�ߣ�ֻ����Ϊ�ʼǻ����ֵ䣬������ҵ��á�" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size=" + titleScale + ">����</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "921632448@qq.com" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size=" + titleScale + ">�汾</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "�汾1.0" +
            "</size></color>", contentStyle, GUILayout.Height(60));
    }

    // ������������
    private Texture2D CreateBackgroundTexture()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, bgColor);
        texture.Apply();
        return texture;
    }

    private GUIStyle GetGUIStyle()
    {
        //����ͨ��
        GUIStyle contentStyle = new GUIStyle(EditorStyles.label) { richText = true };
        contentStyle.fontSize = 20;
        contentStyle.fontStyle = FontStyle.Bold;
        contentStyle.normal.textColor = titleColor;
        contentStyle.wordWrap = true; // �����Զ�����
        contentStyle.normal.background = CreateBackgroundTexture();
        return contentStyle;
    }
}
