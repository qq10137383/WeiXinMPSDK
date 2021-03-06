﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
  
    文件名：TenPayV3RefundQueryRequestData.cs
    文件功能描述：微信支付统一下单请求参数
    
    创建标识：Senparc - 20161227
----------------------------------------------------------------*/

namespace Senparc.Weixin.MP.TenPayLibV3
{
    /// <summary>
    /// 微信支付提交的XML Data数据[查询退款]
    /// </summary>
    public class TenPayV3RefundQueryRequestData
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 商户自定义的终端设备号，如门店编号、设备的ID
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部的订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户侧传给微信的退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信生成的退款单号，在申请退款接口有返回
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        /// 商品信息
        /// </summary>
        public string SignType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        public readonly RequestHandler PackageRequestHandler;
        public readonly string Sign;

        /// <summary>
        /// 查询退款 请求参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="mchId"></param>
        /// <param name="key"></param>
        /// <param name="nonceStr"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="transactionId"></param>
        /// <param name="outTradeNo"></param>
        /// <param name="outRefundNo"></param>
        /// <param name="refundId"></param>
        /// <param name="signType"></param>
        public TenPayV3RefundQueryRequestData(string appId, string mchId, string key, string nonceStr, string deviceInfo,
            string transactionId, string outTradeNo, string outRefundNo, string refundId, string signType = "MD5")
        {
            AppId = appId;
            MchId = mchId;
            NonceStr = nonceStr;
            DeviceInfo = deviceInfo;
            TransactionId = transactionId;
            OutTradeNo = outTradeNo;
            OutRefundNo = outRefundNo;
            RefundId = refundId;
            SignType = signType;
            Key = key;

            #region 设置RequestHandler

            //创建支付应答对象
            PackageRequestHandler = new RequestHandler(null);
            //初始化
            PackageRequestHandler.Init();
            //设置package订单参数
            PackageRequestHandler.SetParameter("appid", this.AppId); //公众账号ID
            PackageRequestHandler.SetParameter("mch_id", this.MchId); //商户号
            PackageRequestHandler.SetParameter("device_info", this.DeviceInfo);
            PackageRequestHandler.SetParameter("nonce_str", this.NonceStr); //随机字符串
            PackageRequestHandler.SetParameter("sign_type", this.SignType);
            PackageRequestHandler.SetParameter("transaction_id", this.TransactionId);
            PackageRequestHandler.SetParameter("out_trade_no", this.OutTradeNo);
            PackageRequestHandler.SetParameter("out_refund_no", this.OutRefundNo);
            PackageRequestHandler.SetParameter("refund_id", this.RefundId);
            Sign = PackageRequestHandler.CreateMd5Sign("key", this.Key);
            PackageRequestHandler.SetParameter("sign", Sign); //签名

            #endregion
        }
    }
}