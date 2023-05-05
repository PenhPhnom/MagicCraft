/***
*
*	Title:"AB���"��Ŀ
*           �����Դ����
*
*	Description:
*           ����˼·��
*               1�����AB��Դ
*               2���Ա�ǵ���Դ���д��
*               
*
*	Author : PenhPhnom
*
*	Date: 2022.2
*
*	Modify:
*
*/

namespace AssetBundleFramework
{
    using UnityEngine;
    using UnityEditor;
    using UnityEditor.EditorTools;
    using System.IO;


    //��AB������
    public class BuildABWindow : EditorWindow
    {
        private static string abRootPath = "AssetBundles";
        private int toolbarIdx = 0;
        BuildTarget buildTarget = BuildTarget.StandaloneWindows64;

        /// <summary>
        /// �򿪴������ 
        /// </summary>
        [MenuItem("Tools/PackToolsWindow")]
        public static void OpenPackToolWindow()
        {
            BuildABWindow window = GetWindow<BuildABWindow>(false, "�������");
        }

        /// <summary>
        /// ���ƴ���UI
        /// </summary>
        void OnGUI()
        {
            toolbarIdx = GUILayout.Toolbar(toolbarIdx, new[] { "PC", "Android", "IOS" });
            switch (toolbarIdx)
            {
                case 0:
                    buildTarget = BuildTarget.StandaloneWindows64;
                    break;
                case 1:
                    buildTarget = BuildTarget.Android;
                    break;
                case 2:
                    buildTarget = BuildTarget.iOS;
                    break;
                default:
                    break;
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("�Զ����AB����"))
            {
                AutoSetAssetBundleLabel();
            }

            if (GUILayout.Button("���AssetBundles"))
            {
                BuildABResources(buildTarget);
            }

            GUILayout.EndHorizontal();

        }


        /// <summary>
        /// �Զ�����Դ�ļ����ӱ��
        /// </summary>
        private void AutoSetAssetBundleLabel()
        {
            AutoSetAssetBundleLabels.SetABLabel();
        }

        /// <summary>
        /// ����������е�AB��
        /// </summary>
        /// <param name="abOutPathDir">��AB�����·��</param>
        /// <param name="target">��AB��Ŀ��ƽ̨</param>
        private void BuildABResources(BuildTarget target)
        {
            string abOutPathDir = PathTool.GetABOutPath();
            if (!Directory.Exists(abOutPathDir))
            {
                Directory.CreateDirectory(abOutPathDir);
            }
            else
            {
                //ɾ�����е�AB���ļ�
                Directory.Delete(abOutPathDir, true);
                //ȥ��ɾ�����棬ɾ��*.meta�ļ�
                File.Delete(abOutPathDir + ".meta");
                //ˢ��
                AssetDatabase.Refresh();
            }

            BuildPipeline.BuildAssetBundles(abOutPathDir, BuildAssetBundleOptions.None, target);
            Debug.Log("AssetBundle ���δ����ɣ�");
        }


        //д��汾��
        public static void SaveVersion(string version, string package)
        {

        }

    }

}

