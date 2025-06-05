using Task.ThreeLayer.DAL;
using Task.ThreeLayer.Entities;
using Task.ThreeLayer.BLL;

namespace Task.ThreeLayer.Common
{
    public static class DependencyResolver
    {
        private static IBasePersons _basePersons;
        private static IPersonLogic _personLogic;

        public static IBasePersons BasePersons
        {
            get => _basePersons ?? (_basePersons = new BasePersons());
        }

        public static IPersonLogic PersonLogic
        {
            get => _personLogic ?? (_personLogic = new PersonLogic(BasePersons));
        }
    }
}