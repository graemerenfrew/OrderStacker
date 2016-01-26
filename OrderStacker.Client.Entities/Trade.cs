using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Core.Common.Contracts;

namespace OrderStacker.Client.Entities
{
   public class Trade : ObjectBase
    {

       int _TradeId;
        int _OrderId;

        int _OrderHeaderId;

        int _OrderLegId;

        int _Quantity;
        float _Price;
        float _FXRate;
        int _FilledByUserId;
        int _AccountId;

        public int TradeId
        {
            get { return _TradeId; }
            set
            {
                if (_TradeId != value)
                {
                    _TradeId = value;
                    OnPropertyChanged(() => TradeId);
                }
            }
        }

        public int OrderId
        {
            get { return _OrderId; }
            set
            {
                if (_OrderId != value)
                {
                    _OrderId = value;
                    OnPropertyChanged(() => OrderId);
                }
            }
        }

        public int OrderHeaderId
        {
            get { return _OrderHeaderId; }
            set
            {
                if (_OrderHeaderId != value)
                {
                    _OrderHeaderId = value;
                    OnPropertyChanged(() => OrderHeaderId);
                }
            }
        }

        public int OrderLegId
        {
            get { return _OrderLegId; }
            set
            {
                if (_OrderLegId != value)
                {
                    _OrderLegId = value;
                    OnPropertyChanged(() => OrderLegId);
                }
            }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    OnPropertyChanged(() => Quantity);
                }
            }
        }
        public float Price
        {
            get { return _Price; }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }
        public float FXRate
        {
            get { return _FXRate; }
            set
            {
                if (_FXRate != value)
                {
                    _FXRate = value;
                    OnPropertyChanged(() => FXRate);
                }
            }
        }
        public int FilledByUserId
        {
            get { return _FilledByUserId; }
            set
            {
                if (_FilledByUserId != value)
                {
                    _FilledByUserId = value;
                    OnPropertyChanged(() => FilledByUserId);
                }
            }
        }
        public int AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }
    }
}
