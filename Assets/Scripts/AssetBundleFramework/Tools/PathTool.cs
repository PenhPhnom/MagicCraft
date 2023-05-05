/***
*
*	Title:"AB���"��Ŀ
*           ·��������
*
*	Description:
*           ���ܣ�
*               ��������·��������·������
*
*	Author : PenhPhnom
*
*	Date: 2023.5
*
*	Modify:
*
*/

namespace AssetBundleFramework
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PathTool
    {
        //·������
        //AB��Դ�ļ���
        public static string AB_RESOURCE = "AB_Resources";

        //У���ļ�����
        public static string VERIFY_FILE_PATH = "/VerifyFile.txt";

        /*���忽��lua�ļ���·������*/
        //���忽��lua�ļ���ԴĿ¼��lua�༭����
        public const string LUA_DIR_PATH = "LuaScripts/";

        //����Ŀ��Ŀ¼��lua�ļ��ķ�������
        public const string LUA_DEPLOY_PATH = "/Lua";


        //����HTTP���������ӵ�ַ
        public const string SERVER_URL = "http://127.0.0.1:8080/UpdateAssets";


        //·������
        /// <summary>
        /// ��ȡAB��Դ·��
        /// </summary>
        /// <returns></returns>
        public static string GetABResourcePath()
        {
            return Application.dataPath + "/" + AB_RESOURCE;
        }

        /// <summary>
        /// ��ȡ��AB�����·��
        /// �㷨��
        ///     1��ƽ̨(PC/�ƶ���)·��
        ///     2��ƽ̨����
        /// </summary>
        /// <returns></returns>
        public static string GetABOutPath()
        {
            return GetPlatformPath() + "/" + GetPlatformName();
        }

        /// <summary>
        /// ��ȡƽ̨·��
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformPath()
        {
            string strPlatformPath = string.Empty;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strPlatformPath = Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    strPlatformPath = Application.persistentDataPath;
                    break;
                default:
                    break;
            }
            return strPlatformPath;
        }

        /// <summary>
        /// ��ȡƽ̨����
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformName()
        {
            string strPlatformName = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strPlatformName = "Win";
                    break;
                case RuntimePlatform.IPhonePlayer:
                    strPlatformName = "Iphone";
                    break;
                case RuntimePlatform.Android:
                    strPlatformName = "Android";
                    break;
                default:
                    break;
            }
            return strPlatformName;
        }

        /// <summary>
        /// ��ȡUnityWebRequest��AB������·��
        /// </summary>
        /// <returns></returns>
        public static string GetABDownLoadPath()
        {
            string strABDownLoadPath = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor:
                    strABDownLoadPath = "file://" + GetABOutPath();
                    break;
                case RuntimePlatform.IPhonePlayer:
                    strABDownLoadPath = GetABOutPath() + "/Raw/";
                    break;
                case RuntimePlatform.Android:
                    strABDownLoadPath = "jar:file://" + GetABOutPath();
                    break;
                default:
                    break;
            }
            return strABDownLoadPath;
        }

        /// <summary>
        /// ��ȡУ���ļ�·��
        /// </summary>
        /// <returns></returns>
        public static string GetMD5VerifyFilePath()
        {
            string strVerifyFilePath = string.Empty;
            strVerifyFilePath = GetABOutPath() + VERIFY_FILE_PATH;
            return strVerifyFilePath;
        }

    }//Class_end

}

