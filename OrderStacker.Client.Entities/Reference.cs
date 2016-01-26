using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Core.Common.Contracts;

namespace OrderStacker.Client.Entities
{
    public class OrderStatus : ObjectBase
    {
        int _OrderStatusId;
        string _Code;
        string _Description;

        public int OrderStatusId
        {
            get { return _OrderStatusId; }
            set
            {
                if (_OrderStatusId != value)
                {
                    _OrderStatusId = value;
                    OnPropertyChanged(() => OrderStatusId);
                }
            }
        }

        public string Code
        {
            get { return _Code; }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    OnPropertyChanged(() => Code);
                }
            }
        }

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }
    }

    public class OrderType : ObjectBase
    {
        int _OrderTypeId;
        string _Code;
        string _Description;

        public int OrderTypeId
        {
            get { return _OrderTypeId; }
            set
            {
                if (_OrderTypeId != value)
                {
                    _OrderTypeId = value;
                    OnPropertyChanged(() => OrderTypeId);
                }
            }
        }

        public string Code
        {
            get { return _Code; }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    OnPropertyChanged(() => Code);
                }
            }
        }

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }
    }
}
