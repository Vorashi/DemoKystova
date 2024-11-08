using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DemoKystova
{
    public partial class Partner
    {
        public string TypeAndName => type + " | " + name; //нажать ctrl и зайти в глубь, там посмотреть namespace (важно!!!) 

        public string RatingString => "Рейтинг: " + rating;

        private static int GetProductCount(int partnerId)//получение кол-ва продуктов данного партнера 
        {
            //ForEach - перебирает записи по порядку и смотрит совпадают ли ID (номер текущей записи и partnerId). дальше сумму считает 
            int sum = 0;//накопительная переменная 
            App.GetContext().PartnerProduct.ToList().ForEach(product =>
            {
                if (product.id_partner != partnerId)
                    return;//если не совпадает то пропускаем 
                sum += product.quantity;
                //GetValueOrDefault - так как  CountProduct(может быть null), и если все таки оно null, то мы считаем как 0. 
            });

            return sum;
        }

        private static int GetDiscount(int partnerId) // метод расчета скидки 
        {

            var productCount = GetProductCount(partnerId);

            if (productCount < 10000)//расчет скидки по ТЗ 
            {

                return 0;

            }

            if (productCount > 10000 && productCount < 49999)
            {

                return 5;

            }

            if (productCount > 50000 && productCount < 300000)
            {

                return 10;

            }

            return 15;
        }
        public string Discount => GetDiscount(id_partner) + "%";

    }
}
