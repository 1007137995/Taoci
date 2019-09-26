using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityWebSocket
{
    /// <summary>
    /// websocket接口
    /// </summary>
    public class WebSocket : IWebSocket
    {
        #region events
        /// <summary>
        /// 连接事件
        /// </summary>
        public event EventHandler onOpen;

        /// <summary>
        /// 关闭事件
        /// </summary>
        public event EventHandler<CloseEventArgs> onClose;

        /// <summary>
        /// 错误事件
        /// </summary>
        public event EventHandler<ErrorEventArgs> onError;

        /// <summary>
        /// 接受消息事件
        /// </summary>
        public event EventHandler<MessageEventArgs> onMessage;
        #endregion

#if UNITY_WEBGL && !UNITY_EDITOR
        public string address { get { return m_rawSocket.address; } }
        public WebSocketState readyState { get { return m_rawSocket.readyState; } }

        WebSocketJslib.WebSocket m_rawSocket = null;
        public WebSocket(string address)
        {
            m_rawSocket = new WebSocketJslib.WebSocket(address);
            m_rawSocket.onOpen += (o, e) =>
            {
                if (onOpen != null)
                    onOpen(this, EventArgs.Empty);
            };
            m_rawSocket.onClose += (o, e) =>
            {
                if (onClose != null)
                    onClose(this, new CloseEventArgs(e.Code, e.Reason, e.WasClean));
            };
            m_rawSocket.onError += (o, e) =>
            {
                if (onError != null)
                    onError(this, new ErrorEventArgs(e.Message, e.Exception));
            };
            m_rawSocket.onMessage += (o, e) =>
            {
                if (onMessage != null)
                    onMessage(this, new MessageEventArgs((Opcode)e.Opcode, e.RawData));
            };
        }

        public void Connect()
        {
            m_rawSocket.Connect();
        }

        public void Send(byte[] data)
        {
            m_rawSocket.Send(data);
        }

        public void Send(string data)
        {
            m_rawSocket.Send(data);
        }

        public void Ping()
        {
            throw new NotImplementedException("WebGL Platform Ping Has Not Implemented Yet!");
        }

        public void Close()
        {
            m_rawSocket.Close();
        }

        public void ConnectAsync()
        {
            Connect();
        }

        public void CloseAsync()
        {
            Close();
        }

        public void SendAsync(byte[] data, Action<bool> completed)
        {
            Send(data);
            completed(true);
        }

#else
        /// <summary>
        /// url地址
        /// </summary>
        public string address { get { return m_rawSocket.Url.AbsoluteUri; } }

        /// <summary>
        /// 网络连接状态
        /// </summary>
        public WebSocketState readyState { get { return (WebSocketState)m_rawSocket.ReadyState; } }

        /// <summary>
        /// websocket实例
        /// </summary>
        WebSocketSharp.WebSocket m_rawSocket = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="address"></param>
        public WebSocket(string address)
        {
            m_rawSocket = new WebSocketSharp.WebSocket(address);
            m_rawSocket.OnOpen += (o, e) =>
            {
                if (onOpen != null)
                    onOpen(this, EventArgs.Empty);
            };
            m_rawSocket.OnClose += (o, e) =>
            {
                if (onClose != null)
                    onClose(this, new CloseEventArgs(e.Code, e.Reason, e.WasClean));
            };
            m_rawSocket.OnError += (o, e) =>
            {
                if (onError != null)
                    onError(this, new ErrorEventArgs(e.Message, e.Exception));
            };
            m_rawSocket.OnMessage += (o, e) =>
            {
                if (onMessage != null)
                    onMessage(this, new MessageEventArgs((Opcode)e.Opcode, e.RawData));
            };
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        public void Connect()
        {
            m_rawSocket.Connect();
        }

        /// <summary>
        /// 发送字节流
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            m_rawSocket.Send(data);
        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data)
        {
            m_rawSocket.Send(data);
        }

        /// <summary>
        /// 测试连通性
        /// </summary>
        public void Ping()
        {
            m_rawSocket.Ping();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            m_rawSocket.Close();
        }

        /// <summary>
        /// 异步连接
        /// </summary>
        public void ConnectAsync()
        {
            m_rawSocket.ConnectAsync();
        }

        /// <summary>
        /// 异步关闭
        /// </summary>
        public void CloseAsync()
        {
            m_rawSocket.CloseAsync();
        }

        /// <summary>
        /// 异步发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="completed"></param>
        public void SendAsync(byte[] data, Action<bool> completed)
        {
            m_rawSocket.SendAsync(data, completed);
        }
#endif

    }
}
