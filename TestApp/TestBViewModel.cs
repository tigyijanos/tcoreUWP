using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCore.UniversalApp.DataOperations;
using TCore.UniversalApp.Interfaces.Common;
using TCore.UniversalApp.Mappers;
using TestApp.Model;

namespace TestApp
{
    public class TestBViewModel : ITCoreViewModel
    {
        public enum MyEnum
        {
            alap
        }

        public async Task InitializeViewModel()
        {
            await Task.FromResult(0);

            var firstList = new List<SecondModelType>()
            {
                new SecondModelType() { Id = Guid.NewGuid(), ByteArray = new string[] { "ss","dd","dsa" } },
                new SecondModelType() { Id = Guid.NewGuid() },
                new SecondModelType() { Id = Guid.NewGuid() },
                new SecondModelType() { Id = Guid.NewGuid() },
                new SecondModelType() { Id = Guid.NewGuid() },
                new SecondModelType() { Id = Guid.NewGuid() }
            };

            var secondItemList = new List<BaseModelType>();

            foreach (var item in firstList)
            {
                var secondItem = new BaseModelType() { Id = Guid.NewGuid(), BaseModel = item };
                secondItemList.Add(secondItem);

                item.BaseModel = item;
                item.MyModelList = secondItemList;
            }

            var targetList = new List<BaseModelType>();

            firstList.CopyAndShallowPropertiesTo(targetList);

            //var localStorage = new LocalStorageService();

            //localStorage.Insert(MyEnum.alap, targetList);

            //var loadedFromDisc = localStorage.Get<List<BaseModelType>>(MyEnum.alap);
        }
    }
}
