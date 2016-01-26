using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Core.Common.Contracts;
using FluentValidation;

namespace OrderStacker.Client.Entities
{
    public class Order : ObjectBase
    {
        int _OrderId;
        int _AccountId;
        bool _IsBuy;
        int _EnteredByUserId;
        int _CommodityId;
        int _OrderTypeId;
        int _OrderStatusId;
        

        public int OrderID
        {
            get
            {
                return _OrderId;
            }
            set
            {
                if (_OrderId != value)
                {
                    _OrderId = value;
                    OnPropertyChanged(() => OrderID);
                }
            }
        }

        public int AccountId
        {
            get
            {
                return _AccountId;
            }
            set
            {
                _AccountId = value;
                OnPropertyChanged(() => AccountId);
            }
        }

        public bool IsBuy
        {
            get
            {
                return _IsBuy;
            }
            set
            {
                if (_IsBuy != value)
                {
                    _IsBuy = value;
                    OnPropertyChanged(() => IsBuy);
                }
            }
        }
        public int EnteredByUserId
        {
            get
            {
                return _EnteredByUserId;
            }
            set
            {
                _EnteredByUserId = value;
                OnPropertyChanged(() => EnteredByUserId);
            }
        }

        public int CommodityId
        {
            get
            {
                return _CommodityId;
            }
            set
            {
                _CommodityId = value;
                OnPropertyChanged(() => CommodityId);
            }
        }
        public int OrderTypeId
        {
            get
            {
                return _OrderTypeId;
            }
            set
            {
                _OrderTypeId = value;
                OnPropertyChanged(() => OrderTypeId);
            }
        }

        public int OrderStatusId
        {
            get
            {
                return _OrderStatusId;
            }
            set
            {
                _OrderStatusId = value;
                OnPropertyChanged(() => OrderStatusId);
            }
        }


        class OrderValidator : AbstractValidator<Order>
        {
            public OrderValidator()
            {
                RuleFor(obj => obj.OrderStatusId).NotEmpty();
                RuleFor(obj => obj.AccountId).NotEmpty();
                RuleFor(obj => obj.EnteredByUserId).NotEmpty();
                RuleFor(obj => obj.OrderTypeId).NotEmpty();
                RuleFor(obj => obj.CommodityId).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new OrderValidator();
        }
    }

    public class OrderHeader : ObjectBase
    {

        int _OrderHeaderId;
        int _TotalQuantity;
        DateTime _ValidUntilTime;
        bool _Active;

        public int OrderHeaderId
        {
            get
            {
                return _OrderHeaderId;
            }
            set
            {
                _OrderHeaderId = value;
                OnPropertyChanged(() => OrderHeaderId);
            }
        }
        public int TotalQuantity
        {
            get
            {
                return _TotalQuantity;
            }
            set
            {
                _TotalQuantity = value;
                OnPropertyChanged(() => TotalQuantity);
            }
        }
        public DateTime ValidUntilTime
        {
            get
            {
                return _ValidUntilTime;
            }
            set
            {
                _ValidUntilTime = value;
                OnPropertyChanged(() => ValidUntilTime);
            }
        }
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
                OnPropertyChanged(() => Active);
            }
        }


        class OrderHeaderValidator : AbstractValidator<OrderHeader>
        {
            public OrderHeaderValidator()
            {
                RuleFor(obj => obj.TotalQuantity).NotEmpty();
                RuleFor(obj => obj.ValidUntilTime).NotEmpty(); 
            }
        }

        protected override IValidator GetValidator()
        {
            return new OrderHeaderValidator();
        }
    }


    public class OrderLeg : ObjectBase
    {
        int _OrderLegId;
        bool _IsBuy;
        int _Quantity;
        DateTime _PromptDate;
        float _Limit;
        float _StopLoss;
        string _CurrencyISOCode;
        float _Rate;
        float _BaseLimit;

        public int OrderLegId
        {
            get
            {
                return _OrderLegId;
            }
            set
            {
                _OrderLegId = value;
                OnPropertyChanged(() => OrderLegId);
            }
        }
        public bool IsBuy
        {
            get
            {
                return _IsBuy;
            }
            set
            {
                _IsBuy = value;
                OnPropertyChanged(() => IsBuy);
            }
        }
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                OnPropertyChanged(() => Quantity);
            }
        }
        public DateTime PromptDate
        {
            get
            {
                return _PromptDate;
            }
            set
            {
                _PromptDate = value;
                OnPropertyChanged(() => PromptDate);
            }
        }
        public float Limit
        {
            get
            {
                return _Limit;
            }
            set
            {
                _Limit = value;
                OnPropertyChanged(() => Limit);
            }
        }
        public float StopLoss
        {
            get
            {
                return _StopLoss;
            }
            set
            {
                _StopLoss = value;
                OnPropertyChanged(() => StopLoss);
            }
        }
        public string CurrencyISOCode
        {
            get
            {
                return _CurrencyISOCode;
            }
            set
            {
                _CurrencyISOCode = value;
                OnPropertyChanged(() => CurrencyISOCode);
            }
        }

        public float Rate
        {
         get
            {
                return _Rate;
            }
            set
            {
                _Rate = value;
                OnPropertyChanged(() => Rate);
            }
        } 

        public float BaseLimit
        {
            get
            {
                return _BaseLimit;
            }
            set
            {
                _BaseLimit = value;
                OnPropertyChanged(() => BaseLimit);
            }
        }

        class OrderLegValidator : AbstractValidator<OrderLeg>
        {
            public OrderLegValidator()
            {
                RuleFor(obj => obj.BaseLimit).GreaterThan(0);
                RuleFor(obj => obj.Rate).NotEmpty();
                RuleFor(obj => obj.PromptDate).NotEmpty();
                RuleFor(obj => obj.Quantity).GreaterThan(0);
                RuleFor(obj => obj.IsBuy).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new OrderLegValidator();
        }
         
    }
}
