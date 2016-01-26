using Core.Common.Core;

namespace OrderStacker.Client.Entities
{
    public class Account : ObjectBase
    {
        int _AccountId;
        string _Description;
        string _ShortCode;

        public int AccountId
        {
            get
            {
                return _AccountId;
            }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged(() => AccountId);
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
