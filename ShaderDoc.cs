using UnityEditor;
using UnityEngine;

public class ShaderDoc : EditorWindow
{
    /// <summary>
    /// 当前编辑器窗口实例
    /// </summary>
    private static ShaderDoc instance;
    private string[] buttons = { "GPU(部件、性能参数)","Pipline(渲染管线)","Properties(属性相关)","Semantics(语义)","Tags(标签)","Render State(渲染设置)","Compile Directives(编译指令)",
                                "Transformations(空间变换)","Other(其它语法)","BuildIn Variables(内置变量)","Predefined Macros(官方预定义宏)","Platform Differences(平台间的差异性)",
                                "Math(数学运算)","Lighting(光照)","Miscellaneous(杂项)","Error Debug(常见报错信息)","WWW(网页推荐)","Setup(设置)","Announcement(注意事项)","About(关于)"};
    int selectedButtonIndex = 0;
    float splitPos = 0.15f;
    private Vector2 leftScroll; // 滚动视图的滚动位置
    private Vector2 rightScroll; // 滚动视图的滚动位置

    // 定义文本颜色
    Color titleColor = Color.black;
    string titleStr = "#000000";
    Color descColor = Color.gray;
    string descColorStr = "#7B7B7B";
    Color bgColor = new Color(160f / 255f, 240f / 255f, 160f / 255f);
    string bgStr = "#8CF0A0";
    int titleScale = 25;
    int descScale = 18;
    int interspaceScale = 5;
    [MenuItem("笔记/shader")]
    static void ShowExcelTools()
    {
        //获取当前实例
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

        // 左侧导航栏或面板
        GUILayout.BeginVertical(GUILayout.Width(position.width * splitPos));
        leftScroll = EditorGUILayout.BeginScrollView(leftScroll, GUILayout.ExpandWidth(true));
        //GUILayout.Label("标题", EditorStyles.boldLabel);
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

        // 右侧内容区域
        // 滚动视图
        rightScroll = EditorGUILayout.BeginScrollView(rightScroll, GUILayout.ExpandWidth(true));
        GUILayout.BeginVertical();
        //GUILayout.Label("内容", EditorStyles.boldLabel);
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
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>部件</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GPU</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Graphic Processing Unit,简称GPU，中文翻译为图形处理器。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BIOS</size>\n<color=#"+descColorStr+"><size="+descScale+">BIOS是Basic Input Output System的简称，也就是基本输入输出系统。" +
            "显卡BIOS主要用于存放显示芯片与驱动程序之间的控制程序，另外还保存显卡的型号、规格、生产厂家以及出厂时间等信息。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PCB</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Printed Circuit Board,显卡PCB就是印制电路板，除了用于固定各种小零件外，PCB的主要功能是提供其上各项零件的相互电气连接。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">晶振</size>\n<color=#"+descColorStr+"><size="+descScale+">Crystal，石英振荡器的简称，是时钟电路中最重要的部分。" +
            "显卡晶振为27MH，其作用是向显卡各部分提供基准频率，晶振就像个标尽尺，工作频率不稳定会造成相关设备工作频率不稳定。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">电容</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "在显卡上是两个直立的零件，电容对显卡主要起滤波和稳定电流的作用，只有在保证电流稳定的情况下，显卡才能正常的工作。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>性能参数</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">显卡架构</size>\n<color=#"+descColorStr+"><size="+descScale+">就是指显示芯片各种处理单元的组成和工作模式，在参数相同的情况下，架构越先进，效率就越高，性能也就越强。" +
            "而同架构的显卡 最重要的指标由处理器数量、核芯频率、显存、位宽来决定。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">核心频率</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "显卡的核心频率是指显示核心的工作频率。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">显存</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "也被叫做帧缓存，它的作用是用来存储显卡芯片处理过或者即将提取的渲染数据。" +
           "显示芯片处理完数据后会将数据保存到显存中，然后由RAMDAC(数模转换器)从显存中读取出数据并将数字\n" +
           "信号转换为模拟信号，最后由屏幕显示出来。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">显存位宽</size>\n<color=#"+descColorStr+"><size="+descScale+">显存位宽是显存在一个时钟周期内所能传送数据的位数，位数越大则瞬间能传输的数据量就越大。" +
           "显存带宽 = 显存频率 * 显存位宽 / 8。举例: 500MHz * 256bit / 8=16GB/s</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">显存速度</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "显存速度一般以ns(纳秒)为单位。常用的显存速度有7ns、5ns、1.1ns等，越小速度越快，性能越好。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">显存频率</size>\n<color=#"+descColorStr+"><size="+descScale+">显存频率在一定程度上反应着显存的速度，以MH(兆赫兹)为单位。显存频率与显存时钟周期是相关的，二者成倒数关系:" +
           "显存频率 = 1 / 显存时钟周期。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowPipline()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>应用程序阶段(Application Stage)</color>",
            new GUIStyle(EditorStyles.boldLabel){ richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Application Stage</size>\n<color=#"+descColorStr+"><size="+descScale+">此阶段一般由CPU将需要在屏幕上绘制的几何体、" +
            "摄像机位置、光照纹理等输出到管线的几何阶段</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>几何阶段(Geometry Stage)</color>", new GUIStyle(EditorStyles.boldLabel) { richText = true });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">模型和视图变换(Model and View Transform)</size>\n<color=#"+descColorStr+"><size="+descScale+">模型和视图变换阶段分为模型变换和视图变换\n" +
            "模型变换的目的是将模型从本地空间变换到世界空间当中，而视图变换的目的是将摄像机放置于坐标原点(以是裁剪和投影操作梗简单高效)，\n" +
            "将模型从世界空间变换到相机空间，以方便后续步骤操作。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">顶点着色(Vertex Shading)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点着色阶段的目的在于确定模型上顶点处的光照效果,其输出结果(颜色、向量、纹理坐标等)会被发送到光栅化阶段以进行插值操作。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">几何、曲面细分着色器</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "[可选项]分为几何着色器(Geometry hader)和曲面细分着色器(Tessellation Shader)，主要是对顶点进行增加与删除修改等操作。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">投影 (Projection)</size>\n<color=#"+descColorStr+"><size="+descScale+">投影阶段分为正交投影与透视投影\n" +
            "投影其实就是矩阵变换，最终会使坐标位于归一化的设备坐标中,之所以叫投影就是因为最终Z轴坐标将被舍弃，\n" +
            "也就是说此阶段主要的目的是将模型从三维空间投射到了二维的空间中的过程\n(但是坐标仍然是三维的，只是显示上看是二维的)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">裁剪 (Clipping)</size>\n<color=#"+descColorStr+"><size="+descScale+">裁剪根据图元在视体的位置分为三种情况:\n" +
            "1.当图元完全位于视体内部,那么它可以直接进行下一个阶段。\n" +
            "2.当图元完全位于视体外部,则不会进入下个阶段，直接丢产。\n" +
            "3.当图元部分位于视体内部,则需要对位于视体内的图元进行裁剪处理。" +
            "最终的目的就是对部分位于视体内部的图元进行裁剪操作，以使处于视体外部不需要渲染的图元进行裁剪丢弃。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">屏幕映射 (Screen Mapping)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "屏幕映射阶段的主要目的，是将之前步骤得到的坐标映射到对应的屏带坐标系上" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>光栅化阶段(Rasterizer Stage)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">三角形设定 (Triangle Setup)(Model and View Transform)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "此阶段主要是将从几何阶段得到的一个个顶点通过计算来得到一个个三角形网格。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">三角形遍历 (Triangle Traversal)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "此阶段将进行逐像素遍历检查操作，以检查出该像素是否被上一步得到的三角形所覆盖，这个查找过程被称为三角形遍历。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">像素着色(Pixelshading)(Triangle Traversal)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对应于ShaderLab中的frag函数,主要目的是定义像素的最终输出颜色。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">混合 (Merging)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "主要任务是合成当前储存于缓中器中的由之前的像素着色阶段产生的片段颜色，此阶段还负责可见性问题(深度测试、模版测试等)的处理。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

    }

    void ShowProperties()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Properties 属性 _Name { \"display name\" , PropertyType} = DefaultValue</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Int(\"Int\",Int) = 1</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:整型\n" +
            "Cg/HLSL:int</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Float(\"Float\"，Float ) = 0</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:浮点数值\n" +
            "Cg/HLSL:可根据需要定义不同的浮点精度\n" +
            "foat 32位浮点数据.常用于世界坐标位置以及UV坐标\n" +
            "half 16位浮点数据,常用于本地坐标位置，方向等\n" +
            "fixed 12位浮点数据,常用于纹理与颜色等低精度的情况" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Slider(\"slider\"，Range(0,1)) = 0</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:数值滑动条\n" +
            "本身还是Float类型，只是通过Range(min,max)来控制滑动条的最小值与最大值</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Color(\"Color\",Color) =(1,1,1,1)</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:颜色属性\n" +
            "Cg/HLSL:foat4/half4/fixed4</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Vector(\"Vector\", Vector) = (0,0,0,0)</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:四维向量\n" +
            "在Properties中无法定义二维或者三维向量，只能定义四维向量</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainTex (\"Texture\"，2D)=\"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:2D纹理\n" +
            "Cg/HLSL:sampler2D/sampler2D_half/sampler2D_float\n" +
            "默认值有white、black、gray、bump以及空，空就是white\n" +
            "\"bump\"是 Unity内置的法线纹理，当没有提供任何法线纹理时，\"bump\"对应模型自带的法线信息</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainTex3D(“Texture”，3D)= \"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:3D纹理\n" +
            "Cg/HLSL:sampler3D/sampler3D_half/sampler3D_float" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_MainCube (\"Texture\"，Cube) = \"white\" {}</size>\n<color=#"+descColorStr+"><size="+descScale+">类型:立方体纹理\n" +
            "Cg/HLSL:samplerCUBE/samplerCUBE_half/samplerCUBE_float" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Attribute</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Header(xxx)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "用于在材质面板中当前属性的上方显示标题xxx，注意只支持关文、数宇、空格以及下划线。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[HideInInspector]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "在材质面饭中隐藏此条属性，在不希望暴露某条属性时可以快速将其隐脑。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Space(n)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "使材质面饭属性之前有间隔，n为间隔的数值大小。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[HDR]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "标记为属性为高动态范围。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[PowerSlider(3)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "滑条曲率,必须如在range属性前面，用于控制滑动的数值比例。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[IntRange]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "必须使用在Range属性之上，以使在材质面饭中滑动时只能生成整数。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Toggle]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "开关,如在数值类型前,可使材质面板中的数值变成开关，0是关，1是开。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Enum(off, 0 , On, 1)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "数值枚举,可直接在cg中使用此关键字来替代数字。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[KeywordEnum (Enum0, Enum1, Enum2, Enum3, Enum4, Enum5, Enum6, Enum7, Enum8)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "关键字枚举,可最多定义8个,需要#pragma mult_compile _ENUM_ENUMO _ENUM_ENUM1 ...来依次声明变体关键字,。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Enum(UnityEngine.Rendering.CullMode)]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "内置枚举，可在Enum()内直接调用Unity内部的枚举.。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[NoScaleOffset]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "只能在纹理属性前，使其隐藏材局面板中的Tiling和Offset。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Normal]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "只能加在纹理属性前，标记此纹理是用来接收法线贴图的，当用户指定了非法线的纹理时会在材质面板上进行警告提示。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[Gamma]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Float和Vector属性默认情况下不会进行颜色空间转换，可以通过添加[Gamma]来指明此属性为sRGB值。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">[PerRendererData]]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "标记当前属性将以材质属性块的形式来自于每个渲染器数据。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowSemantics()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>应用程序到顶点着色器 appdata,a2v</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 vertex : POSITION;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "模型空间中的顶点位置。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">uint vid : SV_VertexID;;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的索引ID。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float3 normal : NORMAL;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的法线信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 tangent : TANGENT;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的切线信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord : TEXCOORDO;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的UV1信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord1 : TEXCOORD1;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的UV2信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord2 : TEXCOORD2;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的UV3信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 texcoord3 : TEXCOORD3;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的UV4信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed4 color : COLOR;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的颜色信息。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_base</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "包含顶点位置，法线和一个纹理坐标。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_tan</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "包含顶点位置，切线，法线和一个纹理坐标。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">appdata_full</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "包含位置、法线、切线、顶点颜色和四个纹理坐标。。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>顶点着色器传递给片元着色器 v2f</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float4 vertex : SV_POSITION;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点的齐次裁剪空间下的坐标,默认况下用POSITION也可以(PS4下不支持)，但是为了支持所有平台，所以最好使用SV_POSITION。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float2 uv : TEXCOORD0;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "TEXCOORDO~N；例如TEXCOORDO、TEXCOORD1、TEXCOORD2...等等，主要用于高精度数据。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed3 color : COLOR0;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "COLORO~N；例如COLOR0、COLOR1、COLOR2...等等，主要用于低精度数据。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">float face : VFACE;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果渲染表面朝向摄像机，则Face节点输出正值1，如果远离摄像机，则输出负值-1。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_VPOS_TYPE screenPos : VPOS;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.当前片元在屏幕上的位置(单位是像素,可除以_ScreenParams.xy来做归一化),此功能仅支持#pragma target 3.0及以上编详指令。\n" +
            "2.大部分平台下VPOS返回的是一个四维向量，部分平台是二维向量，所以需要用UNITY_VPOS_TYPE来统一区分。\n" +
            "3.在使用VPOS时，就不能在v2f中定义SV_POSIT1ON，这样会冲突，所以需要把顶点着色器的入放在()的参数中，并且SV_POSITION添如Out。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">uint vid : sv_VertexID;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "顶点着色器可以接收具有“顶点编号”作为无符号整数的变量,当需要从纹理或ComputeBufers中获取额外的顶点数据时比较有用，\n" +
            "此语义仅支持#pragmatarget 3.5及以上。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">注意事项</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.OpenGLES2.0支持最多8个。\n" +
            "2.0penGL ES3.0支持最多16个。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>片元着色器输出的数据 fragOutput</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed4 color : SV_Target;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "默认RenderTarget,也是默认输出的屏幕上的颜色。\n" +
            "同时支持SV_Target1、SV_Target2...等等。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fixed depth : SV_Depth;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "通过在片元着色器中输出SV_DEPTH语义可以更改像素的深度值,注意此功能相对会消耗性能，在没有特别需求的情况下尽量不要用。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowTags()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Tags</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();

        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Tags {\"TagName1\"=\"Value1\"  \"TagName2\"=\"Value2\"}</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "tags的语法结构，通过Tags{}来表示需要添加的标识,大括号内可以多组Tag,名称(TagName) 和值(Value) 是成对成对出现的，并且全部用字符串表示.\n" +
            "同时支持SV_Target1、SV_Target2...等等。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Queue</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Queue</size>\n<color=#"+descColorStr+"><size="+descScale+">控制渲染顺序，指定该物体属于哪一个渲染队列\n" +
            "渲染队列直接影响性能中的重复绘制，合理的队列可极大的提升渲染效率。\n" +
            "宣染队列数<=2500的对象都被认为是不透明的物体(从前往后染)，>2500的被认为是半透明物体(从后往前渲染)。" +
            "\"Queue\" = \"Geometry+1\" 可通过在值后加数字的方式来改变队列</size></color>", contentStyle);
        EditorGUILayout.EndVertical(); 
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Background\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "值为1000，此队列的对象最先进行渲染。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Geometry\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "值为为2000，通常用于不透明对象，比如场景中的物件与角色等。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"AlphaTest\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "值为2450，透明度测试，默认不透明物体渲染完后就渲染该物体，也就是美术常说的透贴。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Transparent\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "值为3000，常用于半透明对象，渲染时从后往前进行渲染，建议需要混合的对象放入此队列。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"Queue\"=\"Overlavy\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "值为4000,此渲染队列用于叠加效果，最后渲染的东西应该放在这里(例如造头光晕等)。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>RenderType</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">RenderType</size>\n<color=#"+descColorStr+"><size="+descScale+">用来区别这个Shader要染的对象是属于什么类别的，你可以想像成是我们把各种不同的物体按我们需要的类型来进行分类一样。\n" +
            "当然你也可以根据需要改成自定义的名称，这样并不会影响到Shader的效果。\n" +
            "比Tag多用于摄像机的替换材质功能(Camera,SetReplacementShader)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Opaque\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "大多数不透明着色器。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Transparent\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "绝大部分透明的物体、包括粒子特效字体都使用这个。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TransparentCutout\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "透贴着色器，多用于植被等。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Background\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "多用于天空盒着色器。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Overlay\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GUI、光量着色器等。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeOpaque\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain地形中的树干。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeTransparentCutout\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain地形中的树叶。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"TreeBillboard\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain地形中的永对面树。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"Grass\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain地形中的草。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"RenderType\"=\"GrassBillboard'\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Terrain地形中的永对面草。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>DisableBatching</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">DisableBatching</size>\n<color=#"+descColorStr+"><size="+descScale+">通过该标签来直接指明是否对该SubShader使用批处理\n" +
            "在利用Shader在模型的顶点本地坐标下做一些位移动画，而当此模型有批处理时会出现效果不正确的情况，\n" +
            "这是因为批处理会将所有模型特换为世界坐标空间，因此“本地坐标空间”将丢失。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "禁用批处理</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不禁用批处理</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"DisableBatching\" = \"LODFading\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "仅当LOD激活时禁用批处理</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>ForceNoShadowCasting</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForceNoShadowCasting</size>\n<color=#"+descColorStr+"><size="+descScale+">控制使用该SubShader的物体是否会投射阴影\n" +
            "强制关闭投射阴影。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"ForceNoShadowCasting\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "强制关团阴影投射。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForceNoShadowCasting</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不关闭阴影投射。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>IgnoreProjector</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">IgnoreProjector</size>\n<color=#"+descColorStr+"><size="+descScale+">通常用于半透明物体\n" +
            "是否忽略Projector投影器的影响。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"IgnoreProjector\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不受投影器影知响。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"IgnoreProjector\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "受投影器景内。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>CanUseSpriteAtlas</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CanUseSpriteAtlas</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "是否可用于打包图集的精灵。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"CanUseSpriteAtlas\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "支持精灵打包图集。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"CanUseSpriteAtlas\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不支持精灵打包图集。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>PreviewType</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PreviewType</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义材质面板中的预览的模型显示,默认不写或者不为Plane与Skybox时则为圆球。\n" +
            "(PS：新版可以直接修改预览形状)</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PreviewType\"=\"Plane\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "平面。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PreviewType\"=\"Skybox\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "天空盒。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>PerformanceChecks</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PerformanceChecks</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "是否对shader在当前平台进行性能检测，并在材质面饭进行警告提示。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PerformanceChecks\"=\"True\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "开启性能检测提示。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">\"PerformanceChecks\"=\"False\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "关闭性能检测提示。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>LightMode(Pass中)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForwardBase</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "前向渲染，该pass会计算环境光，最重要的平行光，逐顶点光和 Lightmaps" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ForwardAdd</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "前向渲染，该pass会计算额外的逐像素光源，每个pass对应一个光源。光源多该pass会被多次调用 效率变低。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Deferred</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "延时渲染，该Pass会渲染G-buffer" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ShadowCaster</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "把物体的深度信息渲染到阴影映射纹理或深度纹理中，深度渲染与Shadowmap。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PrepassBase</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "遗留的(旧版)延迟渲染，该pass会渲染法线和高光反射的指数部分。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">PrepassFinal</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "遗留的(旧版)延迟渲染，该pass通过合并纹理 光照 自发光来渲染得到最后的颜色。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Vertex</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "遗留的(旧版)顶点照明渲染。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">MotionVectors</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "运动矢量渲染通道。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">VertexLMRGBM</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "旧版顶点追染，支持烘培光照。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">VertexLM</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "日版页点追染，支持烘焙光照，解码为双LDR。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Always</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "所有渲染路径该pass都会渲染，但不计算光照。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Normal</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不与光照交互的规则着色器通道。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Deffered</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "延迟着色器通道。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Meta</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "用于产生反照率和发射值的着色器通道，用作光映射的输入。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ScriptableRenderPipeline</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "自定义脚本通道。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ScriptableRenderPipelineDefaultUnlit</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当光模式被设置为默认未亮或没有光模式时，设置自定义脚本管道。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
    }

    void ShowRenderState()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Cull</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Cull Back | Front | On | Off </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "设置剔除模式\n" +
            "Back: 表示剔除背面，也就是显示正面，这也是最常用的设置。\n" +
            "Front: 表示剔除前面，只显示背面。\n" +
            "Off: 表示关闭剔除，也就是正反面都渲染</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>测试模板</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Stencil</size>\n<color=#"+descColorStr+"><size="+descScale+">通常写在Pass里面最开头，CGPROGRAM之前。\n" +
            "模板缓冲区(StencilBuffer可以为屏幕上的每个像素点保存一个无符号整数值,这个值的具体意义视程序的具体应用而定\n" +
            "在渲染的过程中,可以用这个值与一个预先设定的参考值相比较,根据比较的结果来决定是否更新相应的像素点的颜色值,这个比较的过程被称为模板测试\n" +
            "将StencilBuffer的值与ReadMask与运算，然后Ref信进行Comp比较，结果为tue时进Pass操作，现进Fail操作\n" +
            "，操作值作写入StencilBuffer前先与WriteMask与运算。\n" +
            "stencil｛\n\tRef referenceValue\n\tReadMask  readMask\n\tWriteMask writeMask\n\tComp comparisonFunction\n\tPass stencilOperation\n\tFail stencilOperation\n\tZFail stencilOperation\n｝\n" +
            "Ref:设定的参考值,这个值将用来与模板缓冲中的值进行比较.取值范围位为0-255的整数。\n" +
            "ReadMask:ReadMask的值以及模板中的值进行接位与(&)操作,取值范用也是0-255的整数，默认值为255。\n" +
            "WriteMask:WriteMask的值是当写入栏板缓冲时进行的按位与操作,取值范围是0-255的整数,默认值也是255,即不做任何修改。\n" +
            "Comp:定义Ref与模板缓冲中的值比较的操作函数,默认值为always。\n" +
            "Pass:当模板测试(和深度测试)通过时.则根据(StencilOperation值)对模板缓冲中值进行处理,默认值为keep\n" +
            "Fail:当模板测试(和深度测试)失败时,则根据(StencilOperation值)对模板缓冲中值进行处理，默认值为keep\n" +
            "ZFail:当模板测试通过而深度测试失败时,则根据(StencilOperation值)对模板缓中值进行处理，默认值为keep</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">(比较操作)Comp</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Less:相当于\"<\"操作，即仅当左边<右边，模板测试通过，渲染像素\n" +
            "Greater:相当于\">\"操作，即仅当左边>右边，模板测试通过，渲染像素。\n" +
            "Lequal:相当于\"<=\"操作，即仅当左边<=右边，模板测试通过，渲染像素\n" +
            "Gequal:相当于\">=\"操作，即仅当左边>=右边，模板测试通过，渲染像素\n" +
            "Equal:相当于\"=\"操作，即仅当左边=右边，模板测试通过，渲染像素\n" +
            "NotEqual:相当于\"!=\"操作，即仅当左边!=右边，模板测试通过，渲染像素\n" +
            "Always:不管公式两边为何值，模板测试总是通过，渲染像素\n" +
            "Never:不管公式两边为何值，模板测试总是失败，渲染像素" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">模板缓存区的更新</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Keep:保留当前缓冲中的内容，即stencilBufferValue不变。\n" +
            "Zero:将0写入缓冲，即stencilBufferValue值变为0。\n" +
            "Replace:将参考值写入缓冲，即将referenceValue赋值给stencilBufferValue。\n" +
            "IncrSat:stencilBufferValue加1，如果stencilBufferValue超过255了，那么保留为255，即不大于255。\n" +
            "DecrSat:stencilBufferValue减1，如果stencilBufferValue超过为0，那么保留为0，即不小于0。\n" +
            "Invert:将当前模板缓冲值 (stencilBufferValue) 按位取反。\n" +
            "IncrWrap:当前缓冲的值加1，如果缓冲值超过255了，那么变成0(然后继续自增)。\n" +
            "DecrWrap:当前缓冲的值减1，如果缓冲值已经为0，那么变成255(然后继续自减)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>深度缓冲/color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZTest (Less | Greater | LEqual | GEqual | Equal | NotEqual | Never| Always)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "深度测试，拿当前像素的深度值与深度缓冲中的深度值进行比较，默认值为LEqual。\n" +
            "可通过在属性中添加枚举UnityEngine.Rendering.CompareFunction\n" +
            "Less:小于，表示如果当前像素的深度值小于深度缓冲中的深度值，则通过，以下类同。\n" +
            "Greater:大于。\n" +
            "Lequal:小于等于。\n" +
            "Gequal:大于等于。\n" +
            "Equal:等于。\n" +
            "NotEqual:不等于。\n" +
            "Never:永远不通过。\n" +
            "Always:永远通过。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZTest[unity_GUIZTestMode]</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "unity_GUIZTestMode用于UI材质中，此值默认为LEqual,仅当UI中Canvas模式为Overlay时，值为Always" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ZWrite On | Off </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "深度写入，默认值为On。开启|关闭深度写入" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Offset Factor, Units</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "深度偏移，offset =(m *factor)+(r* units)，默认值为0.0\n" +
            "m:是多边形的深度的斜率(在光栅化阶段计算得出)中的最大值,多边形越是与近裁剪面平行，m信就越接近0。\n" +
            "r:是能产生在窗口坐标系的深度值中可分辨的差异的最小值，r是由具体实现OpenGL的平台指定的一个常量。\n" +
            "结论:一个大于0的offset 会把模型推到离你(摄像机)更远一点的位置，相应地，一个小于0的offset 会把模型拉近。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>颜色遮罩</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ColorMask RGB|A|R、G、B、A的任意组合</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "颜色遮罩，默认伯为:RGBA，表示写入RGBA四个通道" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>混合</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">说明</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "源颜色*SrcFactor + 目标颜色*DstFactor\n" +
            "颜色混合，源颜色与目标颜色以指定的公式进行混合出最终的新颜色。\n" +
            "源颜色:当前Shader计算出的颜色。\n" +
            "目标颜色:已经存在颜色缓存中的颜色，默认值为Blend Off,即表示关团混合。\n" +
            "在混合时可以针对某个RT做混合，比如Blend 3 0ne One,就是对RenderTarget3微混合</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend SrcFactor DstFactor</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "SrcFactor为源颜色，DstFactor为目标颜色，将两者按Op中指定的操作进行混合。\n" +
            "产生的颜色被乘以SrcFactor. 已存在于屏幕的颜色乘以DstFactor，并且两者将被叠加在一起。</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend SrcFactor DstFactor, SrcFactorA DstFactorA</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对RGB和A通道分别做混合操作。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BlendOp Op</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "混合时的操作运算符，默认值为Add (加法操作)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">BlendOp OpColor,OpAlpha</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对RGB和A通道分别指定混合运算符。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">AlphaToMask On|Off</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当值为On时，在使用MSAA时，会根据像素结果将alpha值进行修改多重采样覆盖率，对植被和其他经过alpha测试的着色器非常有用。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend factors</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "混合因子\n" +
            "One:源或目标的完整值\n" +
            "SrcColor: 源的颜色值\n" +
            "SrcAlpha: 源的Alpha值\n" +
            "DstColor:目标的颜色值\n" +
            "DstAlpha:目标的Apha值\n" +
            "OneMinusSrcColor: 1-源颜色得到的值\n" +
            "OneMinusSrcAlpha: 1-源Alpha得到的值\n" +
            "OneMinusDstColor: 1-目标颜色得的值\n" +
            "oneMinusDstAlpha: 1-目标Alpha得到的值" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend Types</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "常用的几种混合类型\n" +
            "Blend SrcApha OneMinusSrcAlpha: Alpha混合，正常的透明度混合\n" +
            "Blend One OneMinusDstColor: Soft Additive比较柔和的相加\n" +
            "Blend One One: Additive相加 线性减淡\n" +
            "Blend OneMinusDstColor One: 柔和相加Soft Additive\n" +
            "Blend DstColor Zero: Multiplicative乘法\n" +
            "Blend DstColor SrcColor: 2 x Multiplicative2倍乘法" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blend operations</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "混合操作的具体运算符\n" +
            "Add: 源+目标\n" +
            "Sub: 源-目标\n" +
            "RevSub; 目标-源\n" +
            "Min: 源与目标中最小值\n" +
            "Max: 源与目标中最大佰\n" +
            "以下仅用于DX11.1中: LogicalClear    LogicalSet    LogicalCopy    LogicalCopyInverted    \n" +
            "LogicalNoop    Logicalinvert    LogicalAnd    LogicalNand    LogicalOr    LogicalNor    LogicalXor    \n" +
            "LogicalEquiv    LogicalAndReverse    LogicalAndinverted    LogicalOrReverse    LogicalOrInverted" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowCompileDirectives()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Pragma</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        // 内容区域
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma target 2.0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "shader编绎目标级别，默认值为2.5。\n" +
            "可以通过#if(SHADER TARGET< 30)来做分支判断。\n" +
            "·2.0: 在unity所有支持的平台上都能够工作。DX9着色器 model2.0。\n" +
            "       有限的算法&贴图指令数量；8个插入器；没有顶点贴图取样；没有片段着色器衍生物；没有清晰细节贴图采样。\n" +
            "·2.5: 几乎和3.0一模一样，除却插入器还是只有8个，并且没有清晰细节贴图采样。\n" +
            "       在Windows Phone上编译成DX11特性级别9.3。\n" +
            "·3.0: DX9着色器 model3.0：派生指令，贴图细节采样，10插入器，更多的计算&贴图指令。\n" +
            "       不支持DX11特性在级别9.x 的GPU上。\n" +
            "       可能在一些OpenGL ES2.0设备上不会被完全支持，取决于驱动扩展和被使用的特性。\n" +
            "·3.5: (or es3.0)OpenGL ES3.0级别能力(DX10 SM4.0在D3D平台，只是没有几何着色器)。\n" +
            "       不支持 DX11 9.x(WinPhone)，OpenGL ES 2.0。\n" +
            "       支持 DX11+, OpenGL 3.2+ ，OpenGL ES3+, Metal ，Vulkan, PS4/XB控制台。\n" +
            "       原生的整数操作，贴图数组等等。\n" +
            "·4.0: DX11 shader model 4.0。\n" +
            "       不支持DX11 9.x (WinPhone), OpenGL ES 2.0/3.0/3.1, Metal。\n" +
            "       支持 DX11+, OpenGL 3.2+, OpenGL ES 3.1+AEP, Vulkan, PS4/XB1 控制台。\n" +
            "       拥有几何着色器，并且3.0有的它都有。\n" +
            "·4.5: (or es3.1)OpenGL ES 3.1级别能力 (DX11 SM5.0 on D3D platforms, 没有镶嵌着色器)。\n" +
            "       不支持DX11 before SM5.0, OpenGL before 4.3 (i.e. Mac), OpenGL ES 2.0/3.0。\n" +
            "       支持DX11+ SM5.0, OpenGL 4.3+, OpenGL ES 3.1, Metal, Vulkan, PS4/XB1控制台。\n" +
            "       拥有计算着色器，随机读写贴图，原子学等，没有几何或者镶嵌着色器。\n" +
            "·4.6: OpenGL 4.1 级别能力(DX11 SM5.0 on D3D platforms,没有计算着色器)。\n" +
            "       这基本上是Macs支持的最高的OpenGL级别了。\n" +
            "       不支持DX11 before SM5.0, OpenGL before 4.1, OpenGL ES 2.0/3.0/3.1, Metal。\n" +
            "       支持 DX11+ SM5.0, OpenGL 4.1+, OpenGL ES 3.1+AEP, PS4/XB1 等控制台。\n" +
            "·5.0: DX11 shader model 5.0。\n" +
            "       不支持 DX11 before SM5.0, OpenGL before 4.3 (i.e. Mac), OpenGL ES 2.0/3.0/3.1, Metal。\n" +
            "       支持 DX11+ SM5.0, OpenGL 4.3+, OpenGL ES 3.1+AEP, Vulkan, PS4/XB1控制台。\n" +
            "PS：所有的类似OpenGL的平台(包含移动平台)都被当做“shader model 3.0”来对待。\n" +
            "WP8/WinRT平台(DX11特性 level 9.x)都被当做“shader model 2.5”来对待。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma require xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "表明shader需要的特性功能。\n" +
            "·interpolators10: 至少支持10个插值器(从顶点到片元)。\n" +
            "·interpolators15: 至少支持15个插值器(从顶点到片元)。\n" +
            "·interpolators32: 至少支持32个插值器(从顶点到片元)。\n" +
            "·mrt4: 至小支持4个Multiple Render Targets。\n" +
            "·mrt8: 至小支持8个Multiple Render Targets。\n" +
            "·derivatives: 片元着色器支持偏导函数(ddx/ddy)。\n" +
            "·samplelod: 纹理LOD采样。\n" +
            "·fragcoord: 将像素的位置(XY为屏上的坐标,ZW为齐次裁剪空间下的深度)传入到片元着色器中。\n" +
            "·integers: 支持真正的整数类型,包括位/移位操作。(PS:在内部，这也会自动将插值器15添加到需求列表中。)\n" +
            "·2darray: 2D纹理数组。\n" +
            "·cubearray: Cubemap纹理数组。\n" +
            "·instancing: GPU实例化。(支持SV_InstanceID输入系统值)\n" +
            "·geometry: 几何着色器。\n" +
            "·compute: 支持计算着色器、结构化缓冲区和原子操作。\n" +
            "·randomwrite or uav: 可以编写任意位置的一些纹理和缓冲区(UAV,unordered access vlews)。\n" +
            "·tesshw: 支持硬件镶嵌，但不一定是镶嵌(hull/domain)着色阶段。例如，Metal支持镶嵌，但不支持船体或领域阶段。\n" +
            "·tessellation: 支持镶嵌(hull/domain)着色器阶段。。\n" +
            "·msaatex: 能够访问多采样纹理(Texture2DMS in HLSL)。\n" +
            "·framebufferfetch or fbfetch: 支持Framebuffer读取(在像素着色器中读取输入像素颜色的能力)。\n" +
            "·sparsetex: 带有常驻信息的稀疏纹理(DirectX术语中的“Tier2”支持;checkaccessfulmapping HLSL函数)。\n" +
            "·setrtarrayindexfromanyshader:支持从任何着色器阶段(不仅仅是几何着色器阶段)设置渲染目标数组索引。\n" +
            "PS:https://docs.unity3d.com/cn/current/Manual/SL-ShaderCompileTargets.html" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "变体声明，常用于不需要程序控制开关的关键字，在编缉器的材质上设置，打包时会自动过滤。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature_local</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "声明本地变体(shader_feature)，unity2019才支持的功能，每个shader最多可以有64个本地变体，不占用全局变体的数量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "变体声明，在打包时会把所有变体都打包进去，这是它与feature的区别。\n" +
            "定义关键字时如果加两个下划线，则表示定义一个空的变体，主要目的是为了节省关健字。\n" +
            "当使用shader变体时，记住在unity中全局关键字最多只有256个,而且在内部已经用了60个了,所以记得不要超标了。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_local</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "声明本地变体(multi_compile)，unity2019才支持的功能，每个Shader最多可以有64个本地变体，不占用全局变体的数量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fog</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "雾类型。使用Unity官方的雾效果，需要在Window-Rendering-Lighting-Environment打开设置面板，勾选Fog开启雾效果：" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fwdbase novertexlight nodynlightmap nodirlightmap</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义在LightMode = ForwardBase的Pass中。\n" +
            "在此Pass中仅只持一个平行灯(逐像素)以及其它逐项点灯和SH光照,这指的作用是一次生成Unity在ForwardBase中需要的各种内置宏\n" +
            "DIRECTIONAL:主平行灯下的效果开启,forwardBase下必开宏。\n" +
            "    例如：#ifdef USING_DIRECTIONAL_LIGHT\n" +
            "                           fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);\n" +
            "                 #else\n" +
            "                           fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz - i.worldPos.xyz);\n" +
            "                 #endif\n" +
            "DIRLIGHTMAP_COMBINED: 烘焙界面中的DirecitonalMode设置为Directional,带方向的LightMap。\n" +
            "DYNAMICLIGHTMAP_ON: RealtimeGI是否开启，动态光照数据。\n" +
            "LIGHTMAP_ON: 当对象标记为LightMap Static并目场景烘焙后开启,使用采样lightmap的方式计算GI\n" +
            "LIGHTMAP_SHADOW_MIXING: 同一片元的阴影是否同时来自于shadow mask(静态阴影)和 shadow map(动态阴影)\n" +
            "                                                                  当灯光设置为Mixed,光照供会模式设置为Subtractive或者shadowMask时开启,Baked Indirect情况下无效。\n" +
            "LIGHTPROBE_SH: 开启光照探针,动态物体会受到LghtProbe的影响,静态物体与此不相关(动态物体接收到了静态物体产生的烘焙阴影，需要通过light probe获得)。\n" +
            "SHADOWS_SCREEN: 在硬件支持屏幕阴影的情况下,同时处理阴影的距离范围内时开启，需要用到shadowmap采样实时阴影。\n" +
            "SHADOWS_SHADOWMASK: 当灯光设置为Mixed,光照烘焙模式设置为shadowMask时开启。用到shadowmask采样烘焙阴影。\n" +
            "VERTEXLIGHT_ON: 是否受到逐顶点的照明\n" +
            "例如: #pragma multi_compile __ LIGHTMAP_ON VERTEXLIGHT_ON</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma multi_compile_fwdadd</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义在LightMode = ForwardBase的Pass中。\n" +
            "在此Pass中用来计算其它的逐像素光照,而此指令的作用是一次性生成Unity在ForwardAdd中需要的各种内置宏\n" +
            "DIRECTIONAL: 判断当前灯是否为平行灯。\n" +
            "DIRECTIONAL_COOKIE: 判断当前灯是否为Cookie平行灯。\n" +
            "POINT: 判断当前灯是否为点灯。\n" +
            "POINT_COOKIE: 判断当前灯是否为Cookie点灯。\n" +
            "SPOT: 判断当前灯灯是为聚光灯" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma skip_variants XXX01 XXX02...</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "剔除指定的变体，可同时剔除多个。\n" +
            "例如: #pragma skip_variants POINT POINT_COOKIE;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma fragmentoption ARB_precision_hint_fastest</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "最快的,意思就是会用低精度(一般是指p16),以提升片元着色器的运行速度,减少时间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma fragmentoption ARB_precision_hint_nicest</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "最佳的,会用高精度(一般是指p32),可能会降低运行速度,增加时间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma enable_d3d11_debug_symbols</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "开启d3d11调试，加此命令后相关的名称与代码不会被剔除，便于在调试工具中进行直看分析。\n" +
            "下载: https://renderdoc.org/\n" +
            "调试: https://zhuanlan.zhihu.com/p/74622572/" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma shader_feature EDITOR_VISUALIZATION</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "开启Material Validation,Scene视图中的模式，用于查看超出范围的像素颜色。\n" +
            "使自定义着色器与材质验证器兼容。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma only_renderers</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "仅编译指定平台的shader。\n" +
            "·d3d11 - Direct3D 11/12\r\n" +
            "·glcore - OpenGL 3.x/4.x\r\n" +
            "·gles - OpenGL ES 2.0\r\n" +
            "·gles3 - OpenGL ES 3.x\r\n" +
            "·metal - iOS/Mac Metal\r\n" +
            "·vulkan - Vulkan\r\n" +
            "·d3d11_9x - Direct3D 11 9.x 功能级别，通常在 WSA 平台上使用\r\n" +
            "·xboxone - Xbox One\r\n" +
            "·ps4 - PlayStation 4\r\n" +
            "·n3ds - Nintendo 3DS\r\n" +
            "·wiiu - Nintendo Wii U" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#pragma exclude_renderers</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "剔除掉指定平台的相关代码,列表参考上面。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>define</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义一个叫NAME的字段，在CG代码中可以通过#if defined(NAME)来判断走不同的分支。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME stuff;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "#define 表示宏定义的指令\r\n" +
            "name    宏名字.后续可以直接输入名字进行使用\r\n" +
            "stuff   编译时候要把宏名字替换成的内容,可以是关键字、常量、关键字、标识符、标点符号、运算符，表达式。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#define NAME 1;</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义一个叫NAME的宇段并且它的值为1。\n" +
            "1.可以通过#if defned(NAME)来判断走不同的分支。\n" +
            "2.可以通过#if NAME来判断走不同的分支(此时值为非0时才有效，为0时不走此分支)\n" +
            "3.还可以直接通过NAME来得到它的值，比如上面的1。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#error xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "多用于分支的判断中，利用此语句可直接输出一条报错信息，内容为xxx。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>include</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#include cginc基础库</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "#include \"UnityCG.cginc\"     包含了最常使用的帮助函数、宏和结构体等。\n" +
            "#include \"Lighting.cginc\"    包含了各种内置的光照模型，如果编写的是Surface Shader的话，会自动包含进来。。\n" +
            "#include \"UnityShaderVariables.cginc\"     在编译Unity Shader时，会被自动包含进来。包含了许多内置的全局变量。\n" +
            "#include \"HLSLSupport.cginc\"                        在编译Unity Shader时会被自动包含进来。声明了很多用于跨平台编译的宏和定义。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowTransformations()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>空间变换(矩阵)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity的内置变换矩阵</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "View空间  Project空间  Model空间    (裁剪空间 = 投影空间)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_MVP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的模型·观察·投影矩阵，用于将顶点/方向矢量从模型空间变换到裁剪空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的模型·观察矩阵，用于将顶点/方向矢量从模型空间变换到观察空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_V</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的观察矩阵，用于将顶点/方向矢量从世界空间变换到观察空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_P</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的投影矩阵，用于将顶点/方向矢量从观察空间变换到裁剪空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_VP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的观察·投影矩阵，用于将顶点/方向矢量从世界空间变换到裁剪空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_T_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_MATRIX_MV的转置矩阵。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_IT_MV</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_MATRIX_MV的逆转置矩阵，用于将法线从模型空间变换到观察空间，也可用于得到UNITY_MATRIX_MV的逆矩阵。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_MATRIX_M</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的模型矩阵，用于将顶点/方向矢量从模型空间变换到世界空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_ObjectToWorld</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当前的模型矩阵，用于将顶点/方向矢量从模型空间变换到世界空间。 旧版命名：_Object2World。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_WorldToObject</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "unity_ObjectToWorld的逆矩阵，用于将顶点/方向矢量从世界空间变换到模型空间。旧版命名：_World2Object。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>空间变换(方法)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityViewToClipPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将点从视图空间变换到裁剪空间(模型空间->齐次裁剪空间)。\n" +
            "float4 UnityWorldToClipPos( in float3 pos )，将位置从世界空间转换到剪辑空间。\n" +
            "float4 UnityViewToClipPos( in float3 pos )，将位置从 View Space 转换为 Clip Space。 \n" +
            "float4 UnityObjectToClipPos(in float3 pos)，将一个顶点位置从Object Space转换到Clip Space。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToViewPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将点从对象空间变换到摄像机空间。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToWorldNormal(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将本对象法线从对象空间变换到世界空间 [单位化]。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityObjectToWorldDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将本对象方向从对象空间变换到世界空间 [单位化]。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityWorldSpaceViewDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据世界空间位置计算到摄像机的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnityWorldSpaceLightDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据世界空间位置计算到光的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">WorldSpaceViewDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据对象空间位置计算到摄像机的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">WorldSpaceLightDir(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据对象空间位置计算到光的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">TRANSFORM_TEX(float4[texcoord], name[str])</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "按比例/偏移特性变换2D UV。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ObjSpaceLightDir(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "计算在对象空间中光的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ObjSpaceViewDir(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "计算在对象空间中视图的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnpackNormal(fixed4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据不同平台解包法线贴图信息，获取法线。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UnpackScaleNormal(half4, half[scale])</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "根据不同平台自动对法线贴图使用正确的解码，并缩放法线。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>基础变换矩阵</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">矩阵变换</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "f(x)+f(y)=f(x+y)\n" +
            "kf(x)=f(kx)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">齐次坐标空间</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "由于3×3矩阵不能表示一个平移操作，就将其扩展到了4×4的矩阵。\n" +
            "把原来的三维矢量转换成四维坐标，也就是齐次坐标。\n" +
            "1.对于一个点，从三维坐标转换成齐次坐标就是把w分量设置为1。\n" +
            "2.对于方向矢量，需要把w分量设置为0。这样当用4×4矩阵进行变换时，平移的效果会被忽略(因为方向矢量没有位置)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">基础变换矩阵</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "使用一个4x4的矩阵来表示平移、旋转和缩放。把表示纯平移、纯旋转和纯缩放的变换矩阵叫做基础变换矩阵。\n" +
            "[ M(3×3)     T(3×3)\n" +
            "  0(1×3)       1]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">平移矩阵</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_translate = float4x4(1,0,0,T.x,\n" +
            "                                                                      0,1,0,T.y,\n" +
            "                                                                      0,0,1,T.z, \n" +
            "                                                                      0,0,0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">缩放矩阵</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_scale = float4x4(S.x,  0,  0,0,\n" +
            "                                                                 0,S.y,  0,0,\n" +
            "                                                                 0,  0,S.z,0, \n" +
            "                                                                 0,  0,  0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">旋转矩阵(X轴)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationX = float4x4(1,     0,          0,0,\n" +
            "                                                                      0, cosθ, sinθ,0,\n" +
            "                                                                      0,-sinθ, cosθ,0, \n" +
            "                                                                      0,     0,          0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">旋转矩阵(Y轴)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationY = float4x4(cosθ,0,sinθ,0,\n" +
            "                                                                      0,          1,       0,0,\n" +
            "                                                                      -sinθ,0, cosθ,0, \n" +
            "                                                                      0,          0,       0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">旋转矩阵(Z轴)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float4x4 M_rotationZ = float4x4(cosθ,  sinθ,0,0,\n" +
            "                                                                      -sinθ, cosθ,0,0,\n" +
            "                                                                      0,                 0,1,0, \n" +
            "                                                                      0,                 0,0,1,)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">复合变换</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "复合变换公式：P_new = M_translation M_rotation M_scalθ P_old\n" +
            "约定变换的顺序就是先缩放，再旋转，最后平移。\n" +
            "同时绕三个轴进行旋转，在Unity中，这个旋转顺序是zxy，旋转过程中的坐标轴不变。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowOther()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Other</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CGPROGRAM/ENDCG</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "cg代码的开始与结束。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CGINCLUDE/ENDCG</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "通常用于定义多段vert/frag函数，然后这段CG代码会插入到所有Pass的CG中，根据当前Pass的设置来选择加载。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Category{}</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义一组所有Subshader共享的命令，位于SubShader外面。\n" +
            "渲染命令的逻辑组。例如着色器可以有多个子着色器,他们都需要关闭雾效果，和混合" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">LOD(Level of Detail)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "shader LOD，可利用脚本来控制LOD级别，通常用于不同配置显示不同的SubShader。\n" +
            "Unity中的内置着色器通过以下方式设置其LOD：\n" +
            "VertexLit kind of shaders(VertexLit着色器) = 100\n" +
            "Decal, Reflective VertexLit(贴花，反射性顶点光) = 150\n" +
            "Diffuse(漫射) = 200\n" +
            "Diffuse Detail, Reflective Bumped Unlit, Reflective Bumped VertexLit(漫反射细节，反射凹凸未照明，反射凹凸VertexLit) = 250\n" +
            "Bumped, Specular(凹凸，镜面反射) = 300\n" +
            "Bumped Specular(凹凸镜面反射) = 400\n" +
            "Parallax(视差) = 500\n" +
            "Parallax Specular(视差镜面反射) = 600" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Fallback\"name\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "备胎，当Shader中没有任何SubShader可执行时，则执行FallBack。默认值为Off,表示没有备胎。\n" +
            "例如: FallBack\"Diffuse\"" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">CustomEditor\"name\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "自定义材质面板，name为自定义的脚本名称。可利用此功能对材质面板进行个性化自定义。\n" +
            "Shader \"example\" {\n  " +
            "// 此处为属性和子着色器...\n  " +
            "CustomEditor \"MyCustomEditor\"}\n" +
            "public class name : ShaderGUI\n" +
            "public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)\n" +
            "通过C#脚本重绘自定义面板UI" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Name\"MyPassName\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "给当前Pass指定名称，以便利用UsePass进行调用。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UsePass \"Unlit/MyShader/MYPASS\"</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "调用其他Shader的Pass，Pass必须全部大写。 Shader的路径也要写全，注意相应的Properties要自行添加。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GrabPass</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GrabPass个抓取当前屏幕存储到_GrabTexture中，每个有此命令的Shader都会每帧执行。\n" +
            "GrabPass{\"TextureName\"}抓取当前屏带存储到自定义的TextureName中，每帧中只有第一个拥有此命令的Shader执行一次。\n" +
            "GrabPass也支持Name与Tags。\n" +
            "通过GrabPass定义一个屏幕抓取的图像：GrabPass{\"_RefractionTex\"}\r\n" +
            "申明定义的图片：sampler2D _RefractionTex;\r\n" +
            "将该图显示出来：fixed4 col = tex2D(_RefractionTex, i.uv);\r\n" +
            "可以得出，直接使用uv渲染的GrabPass图是将相机的图直接放在面片上。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowBuildInVariables()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Camera and Screen</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_WorldSpaceCameraPos(float3)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "该摄像机在世界空间中的位置。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ProjectionParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=1.0,y=Near,z=Far,w=1+1/Far,其中Near和Far分别是近裁剪平面和远裁剪平面和摄像机的距离。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ScreenParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=width,y=height,z= 1+1/width,w = 1+1/height,其中width和height分别是该相机的渲染目标的像素宽度和高度。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_ZBufferParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x=1-Far/Near,y=Far/Near,z=x/Far,w=y/Far,该变量用于线性化Z缓存中的深度值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_OrthoParams(float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x= width,y=height,z没有定义，w=1(正交相机)或w=0(透视相机)，其中width和height是正交相机的宽度和高度。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraProjection(float4x4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "该摄像机的投影矩阵。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraInvProjection(float4x4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "该摄像机的投影矩阵的逆矩阵。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_CameraWorldClipPlanes[6](float4)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "该摄像机的6个裁剪平面在世界空间下的等式，按照顺序：左、右、下、上、近、远裁剪平面。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Time</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_Time:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t是自该场景加载开始所经过的时间,4个分量是(t/20,t,2t,3t)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_SinTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t是时间的正玄弦值，四个分量的值分别是(t/8,t/4,t/2,t)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_CosTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "t是时间的余玄弦值，四个分量的值分别是(t/8,t/4,t/2,t)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_DeltaTime:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "dt是时间增量，4个分量分别是(dt,1/dt,smoothDt,1/smoothDt)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Lighting(ForwardBase & ForwardAdd)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_LightColor0:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "光源颜色(UnityLightingCommon.cginc)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">_WorldSpaceLightPos0:float4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "方向光：(世界空间方向，0)，其他光源：(世界空间位置，1)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_WorldToLight:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "从世界空间到光源空间的变换矩阵，变换得到的坐标用于采样光强衰减纹理。(旧版:_LightMatrix0)\n" +
            "把顶点从世界空间变换到光源空间:\n" +
            "float3 lightCoord = mul(unity_WorldToLight, float4(i.worldPos, 1)).xyz; " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Fog and Ambient</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientSky:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "环境光(Gradient)环境中的Sky Color。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientEquator:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "环境光(Gradient)环境中的Sky Equator。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_AmbientGround:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "环境光(Gradient)环境中的Sky Ground。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_LIGHTMODEL_AMBIENT:fixed4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "环境光照颜色(梯度环境情况下的天空颜色)(旧版变量)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>GPU Instancing</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">描述</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "用于对多个对象(网格一样，材质一样，但是材质属性不一样)合批,单个合批最大上限为511个对象。\n" +
            "GPU Instancing用于相同Mesh物体的大量渲染，弥补了静态合批下重复材质会大量增加内存的缺陷，\n" +
            " 同时也没有动态合批那么多的规则限制。高版本Unity的Standard Shader是支持GPU Instancing的，\n" +
            "在Render Doc中我们可以看到GPU Instancing与其他合批方式最大的不同是GPU Instancing在最后发出Draw Call命令的时候用的是glDrawElementsInstanced接口。\n" +
            "GPU Instancing 还有一个强大的功能是不同的材质属性不会打断合批，我们就可以在一次提交Mesh后，\n" +
            "绘制多个Transform/Color属性不同的物体，GPU Instancing默认支持不同的Transform，其他属性需要在Shader中添加相应声明。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第一步：增加变体让Shader支持instance</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "增加变体使用Shader可以支持Instance。\n" +
            "#pragma multi_compile_instancing\n" +
            "添加此指令后会使材质面板上暴露Instaning开关,同时会生成相应的Instancing变体" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第二步-添加顶点着色器输入宏</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "instancID 加入顶点着色器输入结构，主要作用是使用GPU实例化时，用作顶点属性的索引。\n" +
            "UNITY_VERTEX_INPUT_INSTANCE_ID           (添加在a2v,appdata最后面)\n" +
            "宏翻译后如下其实就是增加了一个SV_InstanceID语义的instanceID变量。\n" +
            "使用此宏，请启用IINSTANCING_ON关键字。否则，Unity不会设置instance ID。\n" +
            "要访问instance ID，请使用#ifdef INSTANCING_ON中的 vertexInput.instanceID 。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第三步-添加顶点着色器输出宏</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "instancID加入顶点着色器输出结构。\n" +
            "UNITY_VERTEX_INPUT_INSTANCE_ID\n" +
            "目的是增加一个SV_InstanceID语义的nstanceID变量，用作顶点属性的索引。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第四步-得到instanceID顶点的相关设置</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_SETUP_INSTANCE_ID(v);\n" +
            "需放在顶点着色器/片元着色器(可选)中最开始的地方,这样才能方问到全局的unity_InstancelD\n" +
            "允许着色器函数访问实例ID。对于顶点着色器，开始时需要此宏。对于片段着色器，此添加是可选的。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第五步-传递instanceID顶点到片元角色器</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_TRANSFER_INSTANCE_ID(v, o);\n" +
            "在顶点着色器中将InstanceID从输入结构复制到输出结构。如果需要访问片段着色器中的每个实例数据，请使用此宏。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">第六步 instanceID在片元的相关设置</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_SETUP_INSTANCE_ID(i);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_INSTANCING_BUFFER_START(Props)/UNITY_INSTANCING_BUFFER_END(Props)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "用于定义 Constant Buffer，每个 Instance 独有的属性必须定义在一个遵循特殊命名规则的 Constant Buffer 中。\n" +
            "将每个你需要实例化的属性都封装在这个常量寄存器中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "第一个参数为属性类型，第二个参数为属性名字，该宏会定义一个 Uniform 数组。\n" +
            "在上面的START和END间把需要的每条属性加进来。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_ACCESS_INSTANCED_PROP(bufferName, propName)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "第一个参数为属性所在缓冲区名字，第二个参数为属性名字。\n" +
            "使用 Instance ID 作为索引到 Uniform 数组中去取当前Instance 对应的数据。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Instancing选项</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对GPU Instancing进行一些设置。\n" +
            "#pragma instancing_options forcemaxcount;batchSize 强制设置单个批次内Instancing的最大数量,最大值和默认值是500。\n" +
            "#pragma instancing_options maxcount;batchSize 设置单个批次内Instancing的最大数量,仅Vulkan, Xbox One和Switch有效" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>三种合批方式的特点</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Static Batching</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "原理: 多个Mesh转换为一个Mesh下的多个SubMesh。\n" +
            "代价: 包体大小增加，内存大小增加(重复的Mesh)。\n" +
            "适用场景: 静止的物体，Mesh的重复率低，材质数量少的场景。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Static Batching（运行时）</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "原理: 多个Mesh转换为一个Mesh下的多个SubMesh。\n" +
            "代价: 运行时一次较大的CPU开销，CPU上多占用一份内存。\n" +
            "适用场景: 相对静止的场景。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Dynamic Batching</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "原理: 把符合合批条件的模型的顶点信息变换到世界空间中，然后通过一次Draw call绘制多个模型。\n" +
            "代价: 动态合批每帧会产生一定的CPU开销。\n" +
            "适用场景: 动态合批每帧会产生一定的CPU开销。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">GPU Instancing</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "原理: 提交一次Mesh在多个地方绘制，要求材质球相同但材质的属性可以不同。\n" +
            "代价: Shader需要支持、要求相对较高图形API版本（Android OpenGL ES 3.0+ / IOS Metal）。\n" +
            "适用场景: 大量相同网格的物体渲染、GPU Skinning。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowPredefinedMacros()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
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
            "桌面端 OpenGL“核心”(GL 3/4)" +
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
            "适用于通用 Windows 平台的 Direct3D 11“功能级别9.x”目标" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADER_API_PS4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "PlayStation 4。也定义了 SHADER_API_PSSL" +
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
            "是针对所有常规移动平台 (GLES、GLES3、METAL) 定义的。\n" +
            "此外，当目标着色语言为GLSL时，还会定义 SHADER_TARGET_GLSL(对于OpenGL/GLES 平台来说始终会定义)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Shader target model(着色器目标模型)</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#if SHADER_TARGET < 30</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对应于#pragma target的值,2.0就是20,3.0就是30" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Unity version</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">#if UNITY_VERSION >= 500</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Unity版本号判断，500表示5.0.0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>platform difference helpers</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UV_STARTS_AT_TOP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "一般此判断当前平台是DX(UV原点在左上角)还是OpenGL(UV原点在左下角)\n" +
            "可以用来判断我们是否是在 Direct3D 平台下。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_NO_SCREENSPACE_SHADOWS</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义移动平台不进行Cascaded ScreenSpace shadow." +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>UI</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UI_CLIP_RECT</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当父级物体有Rect Mask 2D组件时激活。\n" +
            "需要先手动定义此变体#pragma_multi_compile _UNITY_UI_CLIP_RECT。\n" +
            "同时需要声明: _clipRect(一个四维向量，四个分量分别表示RectMask2D的左下角点的xy坐标与右上角点的xy坐标.)\n" +
            "UnityGet2DClipping (float2 position,foat4 clipRect)即可实现遮置。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_UI_ALPHACLIP</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "UNITY_UI_ALPHACLIP是指确定 UI 元素与其他 UI 元素重叠时如何呈现的 alpha（透明度）的设置。\n" +
            " [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip (\"Use Alpha Clip\", Float) = 0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Lighting</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_SHOULD_SAMPLE_SH</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "是否进行计算SH (光照探针与顶点着色)\n" +
            "当静态与动态Lightmap启用时，此项不激活。\n" +
            "当静态与动态Lightmap没有启用时，此项激活。\n" +
            "除ForwardBase其它Pass都不激活，每Pass需要指定UNITY_PASS_FORWARDADD、UNITY_PASS_SHADOWCASTER等。\n" +
            "包含间接漫反射的动态&静态光照贴图，所以忽略掉球面调和光照 || Dynamic & Static lightmaps contain indirect diffuse ligthing, thus ignore SH\n" +
            "#define UNITY_SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_SAMPLE_FULL_SH_PER_PIXEL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "光照贴图uv和来自SHL2的环境颜色在顶点和像素内插器中共享,在启用静态ihtmap和LIGHTPR OBESH时，在像素着色器中执行完整的SH计算\n" +
            "此宏表示我们将采样计算每像素球面调和光照，而不是默认的逐顶点计算球面调和光照并且线性插值到每像素中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">HANDLE_SHADOWS_BLENDING_IN_GI</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当同时定义了SHADOWS_SCREEN与LIGHTMAP_ON同时开启\n" +
            "则HANDLE_SHADOWS_BLENDING_IN_GI定义为1，即宣告在全局照明下也对阴影进行处理。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SHADOW_COORDS(N)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "定义一个foat4类型的变量 shadowCoord,语义为第N个TEXCOORD\n" +
            "SHADOW_COORDS,作用是声明一个用于对阴影纹理采样的uv坐标。一般用于片元着色器的输入结构体中，而且这个宏的参数需要是下一个可用插值寄存器的索引值。\n" +
            "TRANSFER_SHADOW,作用是得到一个用于采样阴影贴图的坐标。\n" +
            "SHADOW_ATTENUATION,作用是使用_SHADOWCOORD对对应的纹理进行采集，得到阴影信息。\n" +
            "例如：float attenuation = SHADOW_ATTENUATION(i)     或者    UNITY_LIGHT_ATTENUATION(attenuation, i, i.worldPos);" +
            "\r\nlight.color = _LightColor0.rgb * attenuation;\n" +
            "作用：让物体能够接收阴影，原理是采样“LightMode” = “ShadowCaster\" Pass里渲染出来的阴影深度图，然后与光照融合，阴影越强烈，贴图像素数值越靠近0\n" +
            "需要在Pass中包含新的内置文件 #include \"AutoLight.cginc\"" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">V2F_SHADOW_CASTER</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "用于LightMode”=“shadowCaster”中,相当于定义了float4 pos:SV_POSITION.\n" +
            "而在使用SHADOWS_CUBE并且不使用SHADOWS_CUBE_IN_DEPTH_TEX时,V2F_SHADOW_CASTER等于float4 pos:SV_POTISION;float3 vec : TEXCOORD0;。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowPlatformDifferences()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>裁剪空间</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">OpenGL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "裁剪空间下坐标范围(-1,1)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">DirectX</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "裁剪空间下坐标范围(1,0)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UNITY_NEAR_CLIP_VALUE</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "载剪空间下的近剪裁值,(DX为1,OpenGL为-1)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>裁剪空间</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">OpenGL</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "裁剪空间下坐标范围(-1,1)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Reversedz</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Reversed direction(反向方向)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "DirectX 11、DirectX 12、PS4、Xbox one、Metal这些平台都属于反向方向。\n" +
            "深度值从近裁剪面到远裁剪面的值为[1 ~ 0]。\n" +
            "载剪空间下的Z轴范围为[near,0]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Traditional direction(传统方向)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "除以上反向方向的平台以外都属于传统方向。\n" +
            "深度值从近裁剪面到远裁剪面的值为[O~1]\n" +
            "裁剪空间下的Z轴范围为:\n" +
            "DX平台=[0,far]           OpenGL平台=[-near,far]" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">SystemInfo.usesReversedZBuffer</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "利用C#判断当前平台是否支持Reversedz。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowMath()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>基本数学运算</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">常量</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
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
        GUILayout.Label("<size="+titleScale+">max(a，b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "比较两个标量或等长向量元素，返回最大值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">min(a，b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "比较两个标量或等长向量元素，返回最小值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mul(M，V)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "表示矩阵M和向量V进行点乘，结果就是对向量V进行M矩阵变换后的值。\n" +
            "mul(M, v) = mul(v, transpose(M)), mul(v, M) = mul(transpose(M), v)\n" +
            "mul(M,N) 计算两个矩阵相乘，如果M为AxB矩阵，N为BxC矩阵，则返回AxC矩阵。\n" +
            "transpose(M)       矩阵转置" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">abs(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "取绝对值，x值可以是向量。\n" +
            "float abs(float a){    return    max(-a,a);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">round(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x四舍五入的值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sqrt(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x的平方根。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">rsqrt(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x的平方根倒数，注意x不能为0，相当于pow(x,-0.5)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">degrees(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将x从弧度转换成角度。\n" +
            "float degrees(float x){    return    57.29577951 * x;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">redians(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将角度转化为弧度。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">noise(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "噪声函数。将uv坐标作为参数x输入，返回的0-1之间的随机值。\n" +
            "PS: 对于同样的输入，返回相同的值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>幂指对函数与偏导数</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">pow(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x的y次幂。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">exp(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回以e为底的指数函数。e的x次方。      e = 2.71828182845904523536" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">exp2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回以2为底，x为指数的幂。2的x次方。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ldexp(x,exp)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x与2的exp次方的乘积。x(2^n)的值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回指定值的以e为底数的对数。ln(x)的值，x必须大于0。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回以2为底数的对数。log2^x的值，x必须大于0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">log10(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回以10为底数的对数。log10^x的值，x必须大于0。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddx(a)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "参数a对应一个像素位置，返回该像素值在X轴的偏导数。\n" +
            "ddx(a) = 该像素点右边的a值 - 该像素点的a值" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddy(a)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "参数a对应一个像素位置，返回该像素值在y轴的偏导数。\n" +
            "ddx(a) = 该像素点下面的a值 - 该像素点的a值" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ddx、ddy</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "在三角形光栅化是，GPU 都是以 2x2 的 block 片段来计算光栅化的。\n" +
            "那么在这个2x2像素块当中，右侧的像素对应的fragment的x坐标减去左侧的像素对应的fragment的x坐标就是ddx；下侧像素对应的fragment的坐标y减去上侧像素对应的fragment的坐标y就是ddy。\n" +
            "边缘突出: 原理就是ddx对ddy分别对每个像素对x、y计算偏导数，得到变化率，变化率高的地方代表设备深度差异大，是边缘。\n" +
            "偏导数ddx/y可以计算我们FragmentShader中任意的变量。向量，矩阵等等。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>三角函数和双曲线函数</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sin(x)、cos(x)、tan(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "sin(x) 输入参数为弧度，计算正弦值，返回值范围[-1,1];\n" +
            "cos(x) 返回x的余弦值，返回值范围[-1,1];\n" +
            "tan(x)输入参数为弧度，计算正切值。\n" +
            "三角函数（弧度制：1°=π/180 rad）" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">asin(x)、acos(x)、atan(x)、atan2(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "asin(x) 反正弦函数，输入的参数取值区间[-1,1],返回角度值范围为[-π/2,π/2];\n" +
            "acos(x) 反余弦函数，输入参数范围[-1,1],返回[0,π]区间的角度值;\n" +
            "atan(x) 反正切函数，返回角度值范围[-π/2,π/2];\n" +
            "atan2(y,x) 计算y/x的反正切值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sinh(x)、cosh(x)、tanh(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "双曲线函数:     x^2-y^2=1\n" +
            "sinh(x) 返回x的双曲正弦值，即0.5*(ex-e-x);\n" +
            "cosh(x) 返回x的双曲余弦函数，即0.5*(ex-e-x);\n" +
            "tanh(x) 返回x的双曲正切值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sincos(float x ,out s, out c)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "该函数是同时计算x的sin值和cos值，其中s=sin(x),c=cos(x),这样比分开计算要快。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>数据范围</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">ceil(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "向上取整，返回>=x的最小整数。\n" +
            "float ceil(float x){    return    -floor(-x);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">floor(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "向下取整，返回<=x的最大整数。(去尾求整)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">step(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x<=y返回1，否则返回0" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">saturate(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果x小于0，返回0；如果x大于1，返回1；否则返回x;\n" +
            "返回将x钳制到[0,1]范围之间的值。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">clamp(x,min,max)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果x小于a，返回a；x大于b，则返回b；否则，返回x;\n" +
            "将x限制在[min，max]范围的值，比min小返回min，比max大返回max" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">fmod(x,y)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x对y取余的余数。\n" +
            "x/y的余数。如果y为0，结果不可预料;\n" +
            "float fmod(float x,float y){    float c = frac(abs(a/b) * abs(b);    return   (a<0) ? -c : c;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">frac(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "取x的小数部分。\n" +
            "返回标量或者是每个向量组件的分数部分。\n" +
            "float frac(float x){    return    x - floor(x);    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">modf(x,out ip)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将x分为小数和整数部分(输出的ip为整数部分，返回值为小数部分)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">lerp(x,y,s)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "s在x到y之间插值。\n" +
            "如果s = 0,返回x;   如果s = 1,返回y;\n" +
            "否则返回x与y的混合值;  x + s*(y-x)或者(1-s)*x + y*s\n" +
            "PS:如果x和y是向量，则权值s必须是标量或者等长的向量。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">smoothstep(min,max,x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "x在[min，max]范围内，就返回介于[0，1]之间的平滑插值。\n" +
            "若x=min,返回0；若x=max,返回1；若x在两者之间，按下列公式返回数据(在0和1之间)：\n" +
            "-2((x-min)/(max-min))^3+3*((x-min)/(max-min))^2;\n" +
            "如果只是想要线性过渡，不需要平滑可直接使用saturate((x-min)/(max-min))。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>类型判断类</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">all(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "确定指定量的所有分量是否均为非零，均非零则返回true，否则返回false\n" +
            "(处理由浮点型、整型、布尔型数据定义的标量、向量或者矩阵)。\n" +
            "bool all(float4 x){    return    a.x && a.y && a.z && a.w;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">any(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "输入的参数只要有一个不为0，则返回true。\n" +
            "bool any(float4 x){    return    a.x || a.y || a.z || a.w;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">clip(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果输入值小于零，则丢弃当前像素 常用于判定范围(不仅仅针对0,返回值为void)。\n" +
            "常用于Alpha Test，如果每个分量代表到平面的距离，还可以用来模拟剪切平面。\n" +
            "void clip(float4 x){    if(any(x<0))   discard;    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sign(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回x的正负性。\n" +
            "如果x<0,返回-1     如果x=零,返回0     如果x>零,返回1" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isinf(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果x参数为+ INF或-INF(无穷+无穷仍无穷，0x3f3f3f3f)，返回true，否则返回False。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isfinite(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "判断标量或者向量中的每个数据是否是无限，如果是返回true，否则返回false。与isinf(x)相反。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">isnan(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "判断标量或者向量中的每个数据是否是非数据，如果是返回true，否则返回false\n" +
            "如果x参数为NAN(非数字)，返回true，否则返回false。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>向量和矩阵类</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">length(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回向量的长度，返回一个向量的模。即sqrt(dot(v,v))" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">normalize(x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "向量归一化，x/length(x) 方向向量归一化(方向一样，但是模为1)。\n" +
            "normalize(x) = rsqrt(dot(x,x))*x" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">distance(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回两个向量之间的距离，不平行的两个向量应该为0，此处表示为根号下各分量之差的平方和。\n" +
            "返回两点之间的欧几里得距离。\n" +
            "float distance(a,b){     float v = b-a;      return  sqrt(dot(v,v));    }" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">dot(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "点积。返回a和b这两个向量的标积/内积/数量积/点积(a在b上的投影长，a·b=|a||b|·cosθ)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">cross(a,b)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "叉积。返回a和b这两个向量的矢积/外积/向量积/叉积(返回值是个向量，而且与a、b都垂直,大小上| a x b | = |a| * |b| * sinθ)\n" +
            "float cross(float3 a,float3 b){     return  a.yzx * b.zxy - a.zxy * b.yzx;    } " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">determinant(m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回指定浮点矩阵的按行列式方式计算的值。矩阵的行列式因子。(只有方阵才有行列式)" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">transpose(m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "返回矩阵m的转置矩阵。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>光线运算类</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">reflect(i,n)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "以i为入射向量n为法线方向的反射光。\n" +
            "PS: 其中i和n必须被归一化，需要注意的是：这个i是指向顶点的；函数只对三元向量有效；" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">refract(i,n,ri)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "以i为入射向量n为法线方向,ri为折射率的折射光。\n" +
            "PS: 其中i和n必须被归一化，如果i和n之间夹角太大，则返回(0,0,0),也就是没有折射光线；函数只对三元向量有效；" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">lit(NdotL,NdotH,m)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "N表示法向量。L表示入射光向量。H表示半角向量。m表示高光向量。\n" +
            "函数计算环境光，散射光，镜面光的贡献，返回四元向量。\n" +
            "X表示环境光的贡献，总是1；Y表示散射光的贡献，如果N.L<0,则为0，否则为N.L; Z表示镜面光的贡献，\n" +
            "如果N.L<0或者N.H<0，则为0；否则为(N.H)^m;W始终为1。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">faceforword(N,I,Ng)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "若Ng*I<0,返回N，否则返回-N。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>纹理映射函数</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">一维纹理查找</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "GPU在PS阶段是在屏幕空间XY坐标系中对每一个像素去对应的纹理中查找对应的纹素来确定像素的颜色;\n" +
            "tex1D(sampler1D tex,float s)  一维纹理查询;\n" +
            "tex1D(sampler1D tex, float s, float dsdx, float dsdy) 使用导数值查询一维纹理;\n" +
            "Tex1D(sampler1D tex, float2 sz) 一维纹理查询，并进行深度值比较;\n" +
            "Tex1D(sampler1D tex, float2 sz, float dsdx,float dsdy) 使用导数值（derivatives）查询一维纹理， 并进行深度值比较;\n" +
            "Tex1Dproj(sampler1D tex, float2 sq) 一维投影纹理查询;\n" +
            "Tex1Dproj(sampler1D tex, float3 szq) 一维投影纹理查询，并比较深度值;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2D纹理查找</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Tex2D(sampler2D tex, float2 s)  二维纹理查询;\n" +
            "Tex2D(sampler2D tex, float2 s, float2 dsdx, float2 dsdy) 使用导数值（ derivatives ）查询二维纹理;\n" +
            "Tex2D(sampler2D tex, float3 sz) 二维纹理查询，并进行深度值比较;\n" +
            "Tex2D(sampler2D tex, float3 sz, float2 dsdx,float2 dsdy) 使用导数值（ derivatives ）查询二维纹理，并进行深度值比较;\n" +
            "Tex2Dproj(sampler2D tex, float3 sq) 二维投影纹理查询;\n" +
            "Tex2Dproj(sampler2D tex, float4 szq) 二维投影纹理查询，并进行深度值比较。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2D纹理查找(OpenGL独有)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "texRECT(samplerRECT tex, float2 s) 二维非投影矩形纹理查询;\n" +
            "texRECT (samplerRECT tex, float3 sz, float2 dsdx,float2 dsdy) 二维非投影使用导数的矩形纹理查询;\n" +
            "texRECT (samplerRECT tex, float3 sz) 二维非投影深度比较矩形纹理查询;\n" +
            "texRECT (samplerRECT tex, float3 sz, float2 dsdx,float2 dsdy) 二维非投影深度比较并使用导数的矩形纹理查询;\n" +
            "texRECT proj(samplerRECT tex, float3 sq) 二维投影矩形纹理查询;\n" +
            "texRECT proj(samplerRECT tex, float3 szq) 二维投影矩形纹理深度比较查询。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">立体纹理查找</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Tex3D(sampler3D tex, float s) 三维纹理查询;\n" +
            "Tex3D(sampler3D tex, float3 s, float3 dsdx, float3 dsdy) 结合导数值（derivatives）查询三维纹理;\n" +
            "Tex3Dproj(sampler3D tex, float4 szq) 查询三维投影纹理，并进行深度值比较;\n" +
            "texCUBE(samplerCUBE tex, float3 s) 查询立方体纹理;\n" +
            "texCUBE (samplerCUBE tex, float3 s, float3 dsdx, float3 dsdy) 结合导数值（derivatives）查询立方体纹理;\n" +
            "texCUBEproj (samplerCUBE tex, float4 sq) 查询投影立方体纹理。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>调试函数</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">void debug(float4 x)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果在编译时设置了 DEBUG ，片段着色程序中调用该函数可以将值 x 作为 COLOR 语义的最终输出；否则该函数什么也不做。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>渲染指令</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">D3D着色器语言使用的指令</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "DXBC指令是D3D着色器语言使用的指令，HLSL高级着色语言经过编译器编译之后，会生成相应的DXBC指令。\n" +
            "DXBC指令可以理解为GPU需要真正执行的指令。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mov dest, src</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "寄存器赋值指令：如果dest是一个整数寄存器，则src.w取整后赋值给dest，否则dest = src。\n" +
            "dest是目标寄存器，src是源寄存器，即在源寄存器和目标寄存器内移动数据。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mova a0, src </size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将浮点寄存器src的值取整后赋值给地址寄存器a0。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">add dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将 src0向量 + src1向量 并存入dest中。\n" +
            "src0 是源寄存器。src1 是源寄存器。举例：dest.x = src0.x + src1.x 。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">abs dest, src</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "对src向量求绝对值并存入dest中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mul dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将 向量src0与向量src1 相乘 并存入dest中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">div dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "将 向量src0与向量src1 相除 并存入dest中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">mad dest, src0, src1，src2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "乘加指令，dest = src0 * src1 + src2。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">dp2 dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "点乘指令，dest= src0.x * src1.x + src0.y * src1.y。\n" +
            "dp3: dest= src0.x * src1.x + src0.y * src1.y + src0.z * src1.z\n" +
            "dp4: dest= src0.x * src1.x + src0.y * src1.y + src0.z * src1.z + src0.w * src1.w" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">rsq dest, src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "rsqrt(src1)，对src0进行平方根的倒数，并存入dest中。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale); 
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">sqrt dest, src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "开平方根，算式为dest = sqrt(src0)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale); 
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">add dest, src0, src1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "add用于加法运算，dest为存储结果的变量，src0以及src1 为俩加数。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">discard src0</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "有条件的标记像素着色结果被丢弃。\n" +
            "其中discard_nz表示不为0时，丢弃；discard_z表示为0时，丢弃。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowLighting()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>法线NormalMap</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">原理</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "如果法线处于世界坐标中的(world space)，那称为world space normal。如果是处于物体本身局部坐标中的，那称为object space normal。\n" +
            "法线被存储在切线空间（Tangent Space Normal）中，切线空间以点的法线方向为Z轴，对应了RGB中的B值，所以法线贴图看上去呈蓝色的。如果存储在世界空间中，则各个方向会表现出不同的颜色值。\n" +
            "目的: 为了提升模型表现细节而又不增加性能消耗，所以不选择提高模型的面数，而是给模型的材质Shader中使用上法线贴图。\n" +
            "Normal Maps（法线贴图）和Height Maps（高度贴图）都是属于Bump Map（凹凸贴图）" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>光照模型</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Lambertian(兰伯特漫反射)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "兰伯特漫反射（Lambertian Diffuse）的光照强度，取决于光照向量与物体表面法线向量间的余弦夹角。\n" +
            "Diffuse = Ambient + Kd * LightColor * max(0,dot(N,L))\n" +
            "Diffuse:最终物体上的漫反射光强\n" +
            "Ambient:环境光强度，为了简化计算，环境光强采用一个常数表示\n" +
            "Kd:物体材质对光的反射系数\n" +
            "LightColor: 光源的强度\n" +
            "N:顶点的单位法线向量\n" +
            "L:顶点指向光源的单位向量\n\n" +
            "C(diffuse) = C光(color)C物(color)( n(法线向量) · l(光源向量) )\n" +
            "// 添加环境光\n" +
            "fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;\n" +
            "// 世界方向光\n" +
            "fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);\n" +
            "fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLight));\n" +
            "//半兰伯特漫反射强度计算\n" +
            "half diffuseStrength = saturate(dot(i.worldNormal, i.worldLightDir) * 0.5 + 0.5);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Phong(高光反射)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Phong光照模型是一种提升物体表面高光的光照模型，高光的强度和范围取决于光源相对物体的方向和观察者相对物体的方向。\n" +
            "Specular = SpecularColor * Ks * pow(max(0,dot(R,V))，Shininess)\n" +
            "Specular:最终物体上的反射高光光强\n" +
            "SpecularColor:反射光的颜色\n" +
            "Ks:反射强度系数，\n" +
            "R:反射向量，可使用2* N* dot(N,L)- L或者refect (-L,N)获得\n" +
            "V:观察方向\n" +
            "N:顶点的单位法线向量\n" +
            "L:顶点指向光源的单位向量\n" +
            "Shininess:乘方运算来模拟高光的变化\n\n" +
            "Phong高光反射颜色 = 入射光颜色 X 高光反射颜色 X max(0,Dot(视角方向，反射方向))^反射系数。\n" +
            "C(diffuse) = C光(color)C物(color)( (2 (n(法线向量) · l(光源向量)) n(法线向量) - l(光源向量) ) · v(光源向量) )^mgless\n" +
            "// 高光反射单位向量（r向量）\n" +
            "fixed3 reflectDir = normalize(reflect(-worldLightDir, i.worldNormal));\n" +
            "// 从物体到摄像机的单位向量（v向量）\n" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(reflectDir,view)),_Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Blinn-Phong(高光反射)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "从代码上来看，Phong-Blinn更像是 Phong的逐像素高光反射的变种。因为进改变了其在片元着色器的部分代码。\n" +
            "Specular = SpecularColor * Ks * pow(max(0,dot(R,H))，Shininess)\n" +
            "Specular:最终物体上的反射高光光强\n" +
            "SpecularColor:反射光的颜色\n" +
            "Ks:反射强度系数，\n" +
            "R:反射向量，可使用2* N* dot(N,L)- L或者refect (-L,N)获得\n" +
            "H:入射光线L与视线V的中间向量，也称为半角向量H = normalize(L+V)\n" +
            "N:顶点的单位法线向量\n" +
            "L:顶点指向光源的单位向量\n" +
            "Shininess:乘方运算来模拟高光的变化\n\n" +
            "直射光 Specular = 直射光 * pow( max(cosθ,0),10)  θ:是法线和x的夹角  x 是平行光和视野方向的平分线。\n" +
            "C(Blinn-Phong-diffuse) = (C光(color)C物(color)) (n(法线向量) · h(光源和摄像机向量的平均单位向量))^mgless\n" +
            "// 从物体到摄像机的单位向量" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));" +
            "// 光源和摄像机向量的平均单位向量（h向量）\n" +
            "fixed3 halfDir = normalize(worldLightDir + viewDir);\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(i.worldNormal, halfDir)), _Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Disney Principled BRDF(迪士尼光照模型)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "从代码上来看，Phong-Blinn更像是 Phong的逐像素高光反射的变种。因为进改变了其在片元着色器的部分代码。\n" +
            "f(l,v) = diffuse + D(θh)F(θd)G(l,v,h)/4cos(θ1)cos(θv)\n" +
            "f(l.v):双向反射分布函数的最终值,l表示光的方向,v表示视线的方向\n" +
            "diffuse:漫反射\n" +
            "D(h):法线分布函数(Normal Distribution Function)描述微面元法线分布的概率,即朝向正确的法线浓度,h为半角向量,表示光的方向与反射方向的半角向量,只有物体的微表面法向m=h时,才会反射到视线中，\n" +
            "D(h)= roughness^2 /n((n·h)2(roughness^2-1)+1)^2\n" +
            "F(v.h):菲涅尔方程(Fresnel Equation),描述不同的表面角下表面所反射的光线所占的比率\n" +
            "F(v,h) = FO +(1-F0)(1-(v·h))^5(FO是0度入射角的菲涅尔反射值)\n" +
            "G(l,v,h): G(l,v,h) = G(θl)G(θv)几何函数(Geometry Function),描述微平面自成阴影的属性,即微表面法向m = h的并未被遮蔽的表面点的百分比，\n" +
            "4cos(n·I)cos(n·v):校正因子(correctionfactor)作为微观几何的局部空间和整个宏观表面的局部空间之间变换的微平面量的校正\n\n" +
            "直射光 Specular = 直射光 * pow( max(cosθ,0),10)  θ:是法线和x的夹角  x 是平行光和视野方向的平分线。\n" +
            "C(Blinn-Phong-diffuse) = (C光(color)C物(color)) (n(法线向量) · h(光源和摄像机向量的平均单位向量))^mgless\n" +
            "// 从物体到摄像机的单位向量" +
            "fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));" +
            "// 光源和摄像机向量的平均单位向量（h向量）\n" +
            "fixed3 halfDir = normalize(worldLightDir + viewDir);\n" +
            "fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(saturate(dot(i.worldNormal, halfDir)), _Gloss);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>shadowMap阴影</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">生成阴影</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.添加\"LightMode\"=\"ShadowCaster\"的Pass。\n" +
            "2.appdata中声明float4 vertex;POSITION;和half3 normal:NORMAL;这是生成阴影所需要的语义。\n" +
            "3.v2f中添V2F_SHADOW_CASTER;用于声明需要传送到片元的数据。\n" +
            "4.在顶点着色器中添 TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)，支持法线偏移阴影，主要是计算明影的偏移以决不正确的Shadow Acne和Petel-Panning现象\n" +
            "5.在片元着色器中添 SHADOW_CASTER_FRAGMENT(i)\n" +
            "// 阴影的对应宏。只有使用了这样的指令，才可以在相关的pass中得到阴影变量。\n" +
            "#pragma multi_compile_shadowcaster" +
            "// 允许大多数着色器的实例化阴影过程，在任何一个可以投射阴影的地方投射阴影。\n" +
            "#pragma multi_compile_instancing " +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">采样阴影</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.在v2f中添加SHADOW_COORDS(3),unity会自动声明一个叫ShadowCoord的foat4变量，用作阴影的采样坐标。（3）指的是TEXCOORD（3）\n" +
            "2.在顶点着色器中TRANSFER_SHADOW(o)，用于将上面定义的_ShadowCord纹理采样坐标变换到相应的屏幕空间纹理坐标，为采样阴影纹理使用。\n" +
            "3.在片元着色器 " +
            "// 与宏协SHADOW_COORDS同工作，得到阴影值\n" +
            "fixed shadow = SHADOW_ATTENUATION(i);\n" +
            "// 与宏协SHADOW_COORDS同工作，包含了光照衰减以及阴影。但由于ForwardBase逐像素光源一般是方向光，衰减固定为1，因此此时衰减无意义，与上式相同。" +
            "UNITY_LIGHT_ATTENUATION(shadow,i,i,worldPos);      其中shadow即存储了采样后的阴影。\n" +
            "return fixed4((diffuse + specular) * shadow + i.vertexLight, 1);\n" +
            "// 只有使用了这样的指令，才可以在相关的pass中得到其他光源的光照变量，例如光照衰减值等。\n" +
            "#pragma multi_compile_fwdbase" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>全局光照Global Illumination（GI）</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">全局光照</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "全局光照是在局部光照的基础上，增加考虑物体与物体之间光线交互。所以说如果局部光照系统就是由光源+待渲染物体+视点组成的话，那么全局光照系统就是由光源+各待渲染物体之间的反射光+待渲染物体+视点组成。\n" +
            "如果没有全局光照技术，这些自发光的表面并不会真的照亮周围的物体，而是它本身看起来更亮了而已。\n" +
            "color = FragmentGI + UNITY_BRDF_PBS +Emission\n" +
            "间接光照:添加\"LightMode\"=\"Meta\"的Pass，可参考内置shader中的Meta Pass" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Light Probe光照探针</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">光照探针</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "Light Probe会采样空间中一点的Irradiance，然后保存到3阶球谐函数中。再在运行时从球谐函数中复原光照信号，并生成新的正确的Irradiance。\n" +
            "规则1:当逐像素平行灯标记为Mixed时,同时场景内有LightProbe时,那么当前平行灯的光照值会自动被LightProbe影响,所以不管物体Shader中是否有SH相关的运算,都会受到LightProbe的影响\n" +
            "规则2:当逐像素平行灯标记为Baked时,同时场景内有LightProbe时,那么需要自行在物体Shader中添SH相关的运算,才会受到LightProbe的影响" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Reflection Probe反射探针</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">反射探针的采样</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "反射探中当前激活的CubeMap存储在unity_SpecCube0当中，必须要用UNITY_SAMPLE_TEXCUBE进行采样，然后需要对其进行解码。\n" +
            "half3 worldView = normalize(UnityWorldSpaceViewDir(i.worldPos));\n" +
            "half3 R = reflect (-worldView，N);\n" +
            "half4 cubemap =UNITY_SAMPLE_TEXCUBE(unity_SpecCube0,R):\n" +
            "half3 skyColor = DecodeHDR(cubemap,unity_SpecCube0_HDR);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);

        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>Fog 雾效</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unity_FogColor</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "内置雾效的颜色。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">方案一:</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.#pragma multi_compile_fog声明雾效所需要的内置变体:FOG_LINEAR FOG_EXP FOG_EXP2。\n" +
            "2.UNITY_FOG_COORDS(i): 声明顶点传入片元的雾效插值器(fogCoord)\n" +
            "3.UNITY_TRANSFER_FOG(o,o.vertex): 在顶点着色器中计算雾效采样\n" +
            "4.UNITY_APPLY_FOG(i.fogCoord，col): 在片元着色器中进行雾效颜色混合" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">方案二:</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "当在v2f中有定义worldPos时，可以把worldPos.w利用起来做为雾效值。\n" +
            "1.#pragma multi_compile_fog声明雾效所需要的内置变体:FOG_LINEAR FOG_EXP FOG_EXP2。\n" +
            "2.UNITY_TRANSFER_FOG_COMBINED_WITH_WORLD_POS(o,o.worldPos)传递雾坐标到像素着色器\n" +
            "在顶点着色器中添加，o.worldPos表示世界空间下的顶点坐标\n" +
            "3.UNITY_EXTRACT_FOG_FROM_WORLD_POS(): 在片元着色器中添加\n" +
            "4.UNITY_APPLY_FOG(_unity_fogCoord,c): 在片元着色器中进行雾效颜色混合" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowMiscellaneous()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>UV</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">UV重映射到中心位置</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = uv * 2 - 1;\n" +
            "将UV值重映射为(-1,-1)~(1,1)，也就是将UV的中心点从左下角移动到中间位置。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">画圆</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float circle = smoothstep(_Radius,(_Radius + _CircleFade), length(uv * 2 - 1));\n" +
            "利用UV来画圆，通过_Radius来调节大小，_CircleFade来调节边缘虚化程序。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">画矩形</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = abs(i.uv.xy * 2 - 1);\n" +
            "float rectangleX = smoothstep(_Width, ( _Width + _RectangleFade), centerUV.x);\n" +
            "float rectangleY = smoothstep( Heigth, ( _Heigth + RectangleFade), centerUV.y);\n" +
            "float rectangleClamp = clamp((rectangleX + rectangleY)，0.0,1.0);" +
            "利用UV来画矩形，_Width调节宽度，_Height调节高度，_RectangleFade调节边缘虚化度。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">黑白棋盘格</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 uv =i.uy;\n" +
            "uv = foor(uv)* 0.5;\n" +
            "float c = frac(uv.x + uv.y) * 2;\n" +
            "return c;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">极坐标</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "float2 centerUV = (i.uy * 2 - 1);\n" +
            "float atan2UV = 1 - abs(atan2(centerUV.g, centerUV.r) / 3.14);\n" +
            "利用UV来实现极坐标。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">将0-1的值控制在某个自定义的区间内</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "frac(x*n+n);\n" +
            "比如frac(i.uv*3.33+3,33);就是将0-1的uv值重新定义为0.33-0.66;" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">随机</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "1.frac(sin(dot(i.uv.xy，foat2(12.9898，78.233)))* 43758.5453);\n" +
            "2.frac(sin(x)*n);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">旋转</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "fixed t= Time.y;\n" +
            "float2 rot= cos(t)*i.uv+sin(t)*float2(i.uv.y , -i.uv.x);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">序列图</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "spitUV是把原有的UV重新定位到左上角的第一格UV上，_Sequence.xy表示的是纹理是由几x几的格子组成的,_Sequence.z表示的是走序列的快慢\n" +
            "float2 splitUV = uv * (1/_Sequence.xy) + float2(0,_Sequence.y - 1/_Sequence.y);\n" +
            "float time =_Time.y * _Sequence.z;" +
            "uv = splitUV + float2(floor(time *_Sequence.x)/_Sequence.x,1-floor(time)/_Sequence.y);" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowErrorDebug()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>常见报错</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">Did not find shader kernel 'frag'to compile at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "找不到片元着色器，检查下是否有正确编写片元着色器fragment。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">syntax error : unexpected token ')at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "这一行存在语法错误,检测这行是否少了什么，如果没有看下它的前一句是否少了最后的分号。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">cannot implicitly convert from 'float2' to 'half4' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "不能隐式的将foat2转换成foat4,需要手动补全，使等号两边分量数量一样才可以。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">invalid subscript 'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "无效的下标，通常是因为xx不存在或者xx的分量不存在导致的。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">undeclared identifier'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xx未定义。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">unrecognized identifier 'xx' at line</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xx未识别到。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">'xx':no matching 2 parameter intrinsic function</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "通常是因为XX方法后面括号内的参数不匹配(数量或者类型)。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">redefinition of 'xx' at xxx</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "xx被重复定义了，看下是否和引用的hlsl或者cginc中的重复了。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">comma expression used where a vector constructor may have been intended at line 48 (on d3d11)</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "逗号的使用场景不对，比如float4 a = (0，0，0，1);应该写成float4 a = foat4(0,0,0,1);。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowWWW()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>网页推荐</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.SelectableLabel("<size="+titleScale+">Shader参考</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
             "https://www.shadertoy.com/" +
             "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">glsl参考</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "https://glslsandbox.com/" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">Shader参考2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://editor.isf.video/shaders?q=&category=&sort=Popularity+%E2%86%93&page=0" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">数学公式</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "https://graphtoy.com/" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">格式转换</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://tool.4xseo.com/" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">DXBC指令</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "http://xiaopengyou.fun/public/2021/01/16/DXBC%E6%8C%87%E4%BB%A4/" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">迪士尼光照模型</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://www.jianshu.com/p/f92c9037355e" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">阴影方案总结</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://zhuanlan.zhihu.com/p/574687894?utm_id=0" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">unity-shader（入门）</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
           "https://blog.csdn.net/qq_50682713/article/details/117993486" +
           "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">unity-shader（中级）</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
          "https://blog.csdn.net/qq_50682713/article/details/125758881?spm=1001.2014.3001.5502" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+ ">项目参考</size><color=red>       强力推荐</color>\n<color=#" + descColorStr+"><size="+descScale+">" +
          "https://github.com/csdjk/LearnUnityShader" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">UI特效</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
          "https://github.com/mob-sakai/UIEffect" +
          "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size="+titleScale+">ShaderLab 开发实战</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
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
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        titleColor = EditorGUILayout.ColorField("文字标题颜色：", titleColor);
        titleStr = ColorUtility.ToHtmlStringRGB(titleColor);
        descColor = EditorGUILayout.ColorField("文字内容颜色：", descColor);
        descColorStr = ColorUtility.ToHtmlStringRGB(descColor);
        bgColor = EditorGUILayout.ColorField("背景颜色：", bgColor);
        bgStr = ColorUtility.ToHtmlStringRGB(bgColor);
        
        titleScale = (int)EditorGUILayout.Slider("文字标题大小：", titleScale,20,50);
        titleScale = Mathf.Clamp(titleScale, 20, 50);

        descScale = (int)EditorGUILayout.Slider("文字内容大小：", descScale,15, 25);
        descScale = Mathf.Clamp(descScale, 15, 25);

        interspaceScale = (int)EditorGUILayout.Slider("间隔大小：", interspaceScale, 4, 12);
        interspaceScale = Mathf.Clamp(interspaceScale, 4, 12);

        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">测试1</size>\n<color=#" + descColorStr + "><size="+descScale+">" +
            "测试1" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size=" + titleScale + ">测试2</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "测试2" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();

        // 创建保存按钮
        if (GUILayout.Button("保存"))
        {
            // 在按钮被点击时执行保存逻辑
            SaveParameters();
            EditorUtility.DisplayDialog("保存成功", "参数保存成功！", "确定");
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
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        //标题
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.FlexibleSpace();
        GUILayout.Label("<color=yellow>减少变体数量的方案</color>",
            new GUIStyle(EditorStyles.boldLabel) { richText = true, alignment = TextAnchor.MiddleCenter });
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">1</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "内存中ShaderLab的大小和变体成正比关系。从减少内存方面应该尽量减少变体数量，可以使用 #pragma skip_variants。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">2</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "在使用ShaderVariantCollection收集变体打包时，只对shader_feature定义的宏有意义，multi_compile的变体不用收集也会被全部打进包体。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">3</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "2018.2新功能OnProcessShader可以移除无用的shader变体。比#pragma skip_variants更合理。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">4</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "项目前期介入美术效果制作流程，规范shader宏定义使用，防止TA为了美术效果过度使用宏定义的情况，以过往项目经验来看，到后期进行此项工作导致的资源浪费非常之大。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size="+titleScale+">5</size>\n<color=#"+descColorStr+"><size="+descScale+">" +
            "ShaderLab在相关shader加入内存时就已经产生，但如果没有被渲染的话不会触发CreateGPUProgram操作，如果提前在ShaderVariantCollection中收集了相关变体并执行了warmup的话，\n" +
            "第一次渲染时就不会再CreateGPUProgram，对卡顿会有一定好处。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
    }

    void ShowAbout()
    {
        //内容通用
        GUIStyle contentStyle = GetGUIStyle();
        EditorGUILayout.BeginVertical();
        GUILayout.Label("<size=" + titleScale + ">作者：羊毛</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "发现任何问题，或者有更好的网站推荐可以给我发邮件。\n" +
            "初学者，只是作为笔记或者字典，方便查找调用。" +
            "</size></color>", contentStyle);
        EditorGUILayout.EndVertical();
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size=" + titleScale + ">邮箱</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "921632448@qq.com" +
            "</size></color>", contentStyle, GUILayout.Height(60));
        GUILayout.Space(interspaceScale);
        EditorGUILayout.SelectableLabel("<size=" + titleScale + ">版本</size>\n<color=#" + descColorStr + "><size=" + descScale + ">" +
            "版本1.0" +
            "</size></color>", contentStyle, GUILayout.Height(60));
    }

    // 创建背景纹理
    private Texture2D CreateBackgroundTexture()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, bgColor);
        texture.Apply();
        return texture;
    }

    private GUIStyle GetGUIStyle()
    {
        //内容通用
        GUIStyle contentStyle = new GUIStyle(EditorStyles.label) { richText = true };
        contentStyle.fontSize = 20;
        contentStyle.fontStyle = FontStyle.Bold;
        contentStyle.normal.textColor = titleColor;
        contentStyle.wordWrap = true; // 可以自动换行
        contentStyle.normal.background = CreateBackgroundTexture();
        return contentStyle;
    }
}
