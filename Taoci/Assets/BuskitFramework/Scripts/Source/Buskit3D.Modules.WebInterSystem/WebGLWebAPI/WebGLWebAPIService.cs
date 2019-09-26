/*******************************************************************************
* ��Ȩ�������������������Ƽ����޹�˾���������а�Ȩ
* �汾������v1.0.0
* ��Ŀ���ƣ�Buskit3D
* �� �� �ƣ�IWebGlWebAPIService
* �������ڣ�2018-04-07 10:58:17
* �������ƣ���־Զ
* CLR �汾��4.0.30319.42000
* ������������������÷���
* �޸ļ�¼��
* ���� ���� ���¹���
* 
******************************************************************************/

using Com.Rainier.Buskit.Unity.Architecture.Injector;

namespace Com.Rainier.Buskit3D
{
    /// <summary>
    /// ��������÷���
    /// </summary>
    public class WebGLWebAPIService : IWebGlWebAPIService
    {
        /// <summary>
        /// WebAPI����ʵ����ӿ�
        /// </summary>
        public IWebGlWebAPIService Wapper = null;

        /// <summary>
        /// ��ӡ��Ϣ
        /// </summary>
        /// <param name="str"></param>
        public void PrintInfo(string str)
        {
            if (Wapper != null)
            {
                Wapper.PrintInfo(str);
            }
        }

        /// <summary>
        /// ��ӡ����
        /// </summary>
        /// <param name="str"></param>
        public void PrintError(string str)
        {
            if(Wapper != null)
            {
                Wapper.PrintError(str);
            }
        }

        /// <summary>
        /// ��ӡ����
        /// </summary>
        /// <param name="str"></param>
        public void PrintWarring(string str)
        {
            if (Wapper != null)
            {
                Wapper.PrintWarring(str);
            }
        }

        /// <summary>
        /// ��strData���ݴ�ŵ�window[objName]����
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="objName"></param>
        public void SaveStringToWindowObject(string strData, string objName)
        {
            if (Wapper != null)
            {
                Wapper.SaveStringToWindowObject(strData, objName);
            }
        }

        /// <summary>
        /// �����ַ����������ļ���
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public void SaveStringToLocalFile(string data, string fileName)
        {
            if(Wapper != null)
            {
                Wapper.SaveStringToLocalFile(data, fileName);
            }
        }

        /// <summary>
        /// �ӱ��ض�ȡ�ļ����ݲ����ݸ�GameObject
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="onLoadedCallback"></param>
        public void ReadFileFromLocal(string gameObjectName, string onLoadedCallback)
        {
            if (Wapper != null)
            {
                Wapper.ReadFileFromLocal(gameObjectName, onLoadedCallback);
            }
        }

        /// <summary>
        /// ��ʼ�����������
        /// </summary>
        public void Initialize()
        {
            this.Wapper = new WebGLWebAPIServiceWapper();
            Wapper.Initialize();
            //ע�������
            if (InjectService.Get<IWebGlWebAPIService>() == null)
            {
                InjectService.RegisterSingleton<IWebGlWebAPIService, WebGLWebAPIService>(this);
            }
        }
    }
}
