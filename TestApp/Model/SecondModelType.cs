﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    [DataContract(IsReference = true)]
    public class SecondModelType
    {
        [DataMember]
        public SecondModelType BaseModel { get; set; }
        [DataMember]
        public List<BaseModelType> MyModelList { get; set; }
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string[] ByteArray { get; set; }
    }
}
