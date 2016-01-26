using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using Core.Common.Contracts;

namespace OrderStacker.Client.Entities
{
    public class Market : ObjectBase
    {
        int _MarketId;
        string _Description;
        string _ShortCode;

        public int MarketId
        {
            get
            {
                return _MarketId;
            }
            set
            {
                if (_MarketId != value)
                {
                    _MarketId = value;
                    OnPropertyChanged(() => MarketId);
                }
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }
        public string ShortCode
        {
            get
            {
                return _ShortCode;
            }
            set
            {
                if (_ShortCode != value)
                {
                    _ShortCode = value;
                    OnPropertyChanged(() => ShortCode);
                }
            }
        }
         
    }
}
