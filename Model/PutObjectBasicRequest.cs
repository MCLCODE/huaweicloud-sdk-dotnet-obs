using System;
using System.Collections.Generic;


namespace OBS.Model
{
    public abstract class PutObjectBasicRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<ExtensionObjectPermissionEnum, IList<string>> extensionPermissionMap;

        private MetadataCollection metadataCollection;

        /// <summary>
        /// ������Զ���Ԫ���ݡ�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public MetadataCollection Metadata
        {
            get
            {

                return this.metadataCollection ?? (this.metadataCollection = new MetadataCollection());
            }
            internal set
            {
                this.metadataCollection = value;
            }
        }

        /// <summary>
        /// �����MIME���͡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// ����Ĵ洢���͡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public StorageClassEnum? StorageClass
        {
            get;
            set;
        }

        /// <summary>
        /// ������ض������ӣ����Խ���ȡ�������������ض���Ͱ����һ�������һ���ⲿ��URL��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string WebsiteRedirectLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Ϊ�û�����OBS������չȨ�ޡ�
        /// </summary>
        /// <param name="domainId">�û���domainId��</param>
        /// <param name="extensionPermissionEnum">OBS��չȨ�ޡ�</param>
        public void GrantExtensionPermission(string domainId, ExtensionObjectPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;

            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);

            if (domainIds == null)
            {
                domainIds = new List<string>();
                ExtensionPermissionMap.Add(extensionPermissionEnum, domainIds);
            }
            domainId = domainId.Trim();
            if (!domainIds.Contains(domainId))
            {
                domainIds.Add(domainId);
            }

        }

        /// <summary>
        /// �����û���OBS������չȨ�ޡ�
        /// </summary>
        /// <param name="domainId">�û���domainId��</param>
        /// <param name="extensionPermissionEnum">OBS��չȨ�ޡ�</param>
        public void WithDrawExtensionPermission(string domainId, ExtensionObjectPermissionEnum extensionPermissionEnum)
        {
            if (string.IsNullOrEmpty(domainId))
            {
                return;
            }

            IList<string> domainIds;
            ExtensionPermissionMap.TryGetValue(extensionPermissionEnum, out domainIds);
            domainId = domainId.Trim();
            if (domainIds != null && domainIds.Contains(domainId))
            {
                domainIds.Remove(domainId);
            }
        }

        internal IDictionary<ExtensionObjectPermissionEnum, IList<string>> ExtensionPermissionMap
        {
            get
            {
                return extensionPermissionMap ?? (extensionPermissionMap = new Dictionary<ExtensionObjectPermissionEnum, IList<string>>());
            }
        }

        /// <summary>
        /// ����ķ���Ȩ�ޡ�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public CannedAclEnum? CannedAcl
        {
            get;
            set;
        }

        /// <summary>
        /// ���������Ӧ�ɹ�����ض����ַ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string SuccessRedirectLocation
        {
            set;
            get;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// ��������SSE����ͷ����Ϣ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public SseHeader SseHeader
        {
            get;
            set;
        }
    }
}
    