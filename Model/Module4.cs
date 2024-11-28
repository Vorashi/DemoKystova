using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKystova.Model
{
    internal class Module4
    {
        private readonly DemoEntities _context;
        public Module4() 
        {
            _context = App.GetContext();
        }
        private int CalcCountMaterial(int idTypeProduct, int idTypeMaterial, int countProduct, double length, double width)
        {
            // Получаем записи из БД
            ProductType productType = _context.ProductType.Where(x => x.id_product_type == idTypeProduct).FirstOrDefault();
            if (productType == null) return -1;

            MaterialType materialType = _context.MaterialType.Where(x => x.id_material_type == idTypeMaterial).FirstOrDefault();
            if (materialType == null) return -1;

            // Проверяем что реализовано положительное число продукции
            if (countProduct < 0)
            {
                return -1;
            }

            // Проверяем что длина и ширина продукции больше нуля
            if (length <= 0 || width <= 0)
            {
                return -1;
            }

            // Получаем "Коэффициент типа продукции" и "процент брака"
            double ratioProductType = (double)productType.coefficient;
            double percentBad = (double)materialType.percent_defect;
            // Проверям что полученные значения больше 0
            if (ratioProductType <= 0 || percentBad <= 0)
            {
                return -1;
            }

            // Вычисляем результат
            double result = (length * width * ratioProductType) * (1 + percentBad) * countProduct;
            // Округляем результат в большую сторону с помощью Ceiling и приводим результат к целому типу данных (int)
            int resultInt = (int)Math.Ceiling(result);

            // Возвращаем результат вычислений, который отражает необходимое количество материала для изготовления продукции определенного типа
            return resultInt;
        }

    }
}
