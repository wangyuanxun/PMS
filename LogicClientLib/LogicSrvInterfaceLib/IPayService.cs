using System.Collections.Generic;
using System.Data;
using EntityLib.Model;

namespace LogicSrvInterfaceLib
{
    /// <summary>
    /// ֧������
    /// </summary>
    public interface IPayService
    {
        /// <summary>
        /// ��Ӷ���
        /// </summary>
        /// <param name="pl">����ʵ��</param>
        /// <param name="shopList">�������Ʒ���б�</param>
        /// <returns>���ض���ID ���ؿ��ַ��������ʧ��</returns>
        string PaymentOrderAdd(PaymentLib pl, List<ShopCartLib> shopList); //�ύ�����
        /// <summary>
        /// ���¶���
        /// </summary>
        /// <param name="pl">����ʵ��</param>
        bool PaymentOrderUpdate(PaymentLib pl); //���¸����
        /// <summary>
        /// ��ȡ��Ʒ��Ϣ
        /// </summary>
        /// <param name="productID">��ƷID</param>
        /// <returns></returns>
        ProductLib ProductGet(int productID);
        /// <summary>
        /// ��ȡ��Ʒ��Ϣ
        /// </summary>
        /// <param name="productType">��Ʒ����</param>
        /// <param name="productGrade">��Ʒ�꼶</param>
        /// <returns></returns>
        ProductLib ProductGet(int productType, int productGrade);
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="guid">����ID</param>
        /// <returns></returns>
        PaymentLib PaymentOrderGet(string guid); //��ȡ������Ϣ
        /// <summary>
        /// ��ȡ���ﳵ
        /// </summary>
        /// <param name="guid">���ﳵGUID��ʶ</param>
        /// <returns></returns>
        List<ShopCartLib> ShopCartListGet(string guid);
        /// <summary>
        /// ���յ�֧�������ص���ʱִ��
        /// </summary>
        /// <param name="outTradeNo">������</param>
        /// <param name="tradeNo">֧�����׺�</param>
        /// <returns></returns>
        bool ResultReceive(string outTradeNo, string tradeNo); //��ֵ�������


             /// <summary>
        ///     ���յ�֧�������ص���ʱִ��(���ֳ�ֵ)
        /// </summary>
        /// <param name="outTradeNo">������</param>
        /// <param name="tradeNo">֧�����׺�</param>
        /// <returns></returns>
        bool IntegralResultReceive(string outTradeNo, string tradeNo);//��ֵ�������


        /// <summary>
        /// ȷ�ϻ��ֶһ���Ʒ
        /// </summary>
        /// <param name="PaymentID">����id</param>
        /// <returns></returns>
        string PointsForAdd(string PaymentID, string UserID);

        /// <summary>
        /// ���վ���Ƿ���ʹ������� ���ݿ���������վ����ʵ��
        /// </summary>
        /// <param name="cardNum">Ҫ�жϵĿ���</param>
        /// <param name="siteDescription">վ��������ʶ</param>
        /// <returns></returns>
        bool CheckCard(int cardNum, string siteDescription);



        /// <summary>
        /// ��ȡ��Ʒ�����Ѹ���
        /// </summary>
        /// <param name="paymentID"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderProcductGetpay(string paymentID, string userid);

        /// <summary>
        /// �����꼶id��ȡ��Ʒ
        /// </summary>
        /// <param name="grade">�꼶id</param>
        /// <returns></returns>
        DataTable ProductByGradeGet(int grade);
        /// <summary>
        /// �����꼶id��ȡ����ѵ����Ʒ
        /// </summary>
        /// <param name="grade">�꼶id</param>
        /// <returns></returns>
        DataTable ProductByGradeSkillGet(int grade);

        /// <summary>
        /// ��ȡ������Ʒ
        /// </summary>
        /// <param name="paymentid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable ProductGetPid(string paymentid, string userid);

        /// <summary>
        /// ����ȷ��
        /// </summary>
        /// <param name="userid">�û�id</param>
        /// <param name="paymentid">����id</param>
        /// <returns></returns>
        bool UpdatePayStatus(string userid, string paymentid);
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="pid">����id</param>
        /// <returns></returns>
        bool DelOrder(string pid);
        /// <summary>
        ///  ��Ʒ����
        /// </summary>
        /// <param name="pid">��Ʒid</param>
        /// <param name="userid">�û�id</param>
        /// <param name="username">�û���</param>
        /// <param name="truename">��ʵ����</param>
        /// <param name="startnumber">���ۼ���</param>
        /// <param name="tips">��������</param>
        /// <param name="paymentid">����id</param>
        /// <param name="shoppinggroup"></param>
        /// <returns></returns>
        bool InsertPingJia(string pid, string userid, string username, string truename, int startnumber, string tips, string paymentid, string shoppinggroup);
        /// <summary>
        /// ��ȡ�Ǽ����۸���
        /// </summary>
        /// <param name="producttype"></param>
        /// <returns></returns>
        int StarNumGet(int producttype);
        /// <summary>
        /// �û�����    
        /// </summary>
        /// <param name="producttype"></param>
        /// <param name="nowpage"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable UserPj(string producttype, int nowpage, int pageSize, ref int count);

        /// <summary>
        /// �����꼶�����ͻ�ȡ��Ʒ
        /// </summary>
        /// <param name="grade">�꼶</param>
        /// <param name="type">1��������2���̳� 3�����4������ѵ����Ƭ 5�������μ���</param>
        /// <returns></returns>
        DataTable ProductByGradeAndType(int grade, int type);
        /// <summary>
        ///  ȷ�϶���
        /// </summary>
        /// <param name="paymentid"></param>
        /// <param name="bank"></param>
        /// <param name="remittancenum"></param>
        /// <param name="userid"></param>
        /// <param name="truename"></param>
        /// <returns></returns>
        bool InsertBank(string paymentid, string bank, string remittancenum, string userid, string truename);

        /// <summary>
        /// ���ݿ��ź������ø�֧��������ϸ��Ϣ
        /// </summary>
        /// <param name="cardNum">����</param>
        /// <returns></returns>
        DataTable PayCardDetailGet(string cardNum);

        /// <summary>
        /// ���¿���״̬
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="cardPwd"></param>
        /// <returns></returns>
        bool UpdatePayCard(string cardNum, int cardPwd);

        /// <summary>
        /// �ж��û�֮ǰ�Ƿ��Ѿ�ʹ�ù���Ʒѧϰ��
        /// </summary>
        /// <param name="accountID">�û�ID</param>
        /// <returns>True:�����ù�����    False:δʹ�ù�����</returns>
        bool CheckGift(string accountID);

        /// <summary>
        /// 1.�޸�֧����״̬(��Ϊ����)
        /// 2.���������Ϊ��Ʒ��,�޸��û���CardNum�ֶ�
        /// 3.���������Ϊ��Ʒ��,���Ƽ����в������ظ�,�����Ƽ����в����¼
        /// 4.��¼��ʹ����־7
        /// </summary>
        /// <param name="accountID">�û�ID</param>
        /// <param name="cardNum">����</param>
        /// <param name="cardType">������</param>
        /// <param name="payMoney">������ֵ</param>
        /// <returns></returns>
        bool SetPayCardInfo(int accountID, string cardNum, int cardType, decimal payMoney);

        #region 20131224 ��ϲ�Ϸ�������
        /// <summary>
        /// ��ȡ֧����̬
        /// </summary>
        /// <param name="comefrom">վ������</param>
        ///<param name="citycode">����id</param>
        /// <returns></returns>
        DataTable ZiFuStatusGet_sql(string comefrom, string citycode);
        /// <summary>
        /// ��ȡ֧����̬��Ĺ��ﳵ��Ĳ�Ʒ
        /// </summary>
        /// <param name="shoppinggroup">���ﳵid</param>
        /// <returns></returns>
        DataTable ZiFuStatusShopCart(string shoppinggroup);
        /// <summary>
        /// ��ȡ������û�����Ϣ
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderUserGet(string userid);
        /// <summary>
        /// ��ȡƽ̨���в�Ʒ
        /// </summary>
        /// <param name="comefrom">ƽ̨��Դ</param>
        /// <returns></returns>
        DataTable ProductAll(string comefrom);

        /// <summary>
        /// �����б� 
        /// </summary>
        /// <param name="comeFrom"></param>
        /// <param name="userid"></param>
        /// <param name="Nowpage"></param>
        /// <param name="PageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable SaleProductGet(int comeFrom, string userid, int Nowpage, int PageSize, ref int count);



        /// <summary>
        /// ��ȡδ�������¼
        /// </summary>
        /// <param name="paymentid">����id</param>
        /// <returns></returns>
        int SelectPaymentNopay(string paymentid);
        /// <summary>
        /// ��ȡ�û�δ����Ķ�������
        /// </summary>
        /// <param name="comeFrom">վ����Դ</param>
        int OrderNoPayCount(int comeFrom, string userid);

        /// <summary>
        /// ��ȡ������Ʒ��Ϣ
        /// </summary>
        /// <param name="pid">��Ʒid</param>
        /// <returns></returns>
        DataTable ProductByIDGet(int pid);

        /// <summary>
        /// ��ȡδ�����Ʒ����
        /// </summary>
        /// <param name="PaymentID"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataTable OrderProcductGet(string PaymentID, string userid);

        /// <summary>
        /// ��ȡ��Ʒ����
        /// </summary>
        /// <param name="nowPage">��ǰҳ��</param>
        /// <param name="pageSize">ÿҳ��Ŀ</param>
        /// <param name="count">�ܹ�����</param>
        /// <param name="productid">��Ʒid</param>
        /// <returns></returns>
        DataTable ProductEvaluationGet(int nowPage, int pageSize, ref int count, string productid);

        /// <summary>
        /// ��ȡ��Ʒ����
        /// </summary>
        /// <param name="PaymentID">�������</param>
        /// <param name="userid">�û�id</param>
        /// <returns></returns>
        DataTable OrderProcductGet2(string PaymentID, string userid);

        /// <summary>
        /// ����ȷ�϶�����ɾ���ɶ���
        /// </summary>
        /// <param name="paymentid">����id</param>
        /// <returns></returns>
        bool DeletePayment(string paymentid);

        /// <summary>
        /// ��ҳ֧���û���̬
        /// </summary>
        /// <param name="schoolid">ѧУ��Ϣ</param>
        /// <returns></returns>
        DataTable IndexPayLog_SQL(int schoolID, int cityid);

        #endregion
    }
}
