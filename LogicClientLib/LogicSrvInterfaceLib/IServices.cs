namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// �������
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// ֧������
        /// </summary>
        IPayService PayService { get; }
        /// <summary>
        /// ��־����
        /// </summary>
        ILogService LogService { get; }
        /// <summary>
        /// �û����ݷ���
        /// </summary>
        IUserService UserService { get; }
        /// <summary>
        /// վ�����ݷ���
        /// </summary>
        ISiteService SiteService { get; }
        /// <summary>
        /// ��ᰲȫƽ̨����
        /// </summary>
        ISocietySafeEduService SocietyService { get; }
        /// <summary>
        /// �������
        /// </summary>
        IMangeService ManageService { get; }

        /// <summary>
        /// ���ַ���
        /// </summary>
        IIntegralService IntegralService { get; }

        /// <summary>
        /// ��������Ȩ
        /// </summary>
        IThirdAuthorization ThirdAuthorization { get; }
    }
}
