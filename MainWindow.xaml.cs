using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQ_запросы_Animal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> stroki = new List<string>() {
        "Не говорят о том, что сделано, то сделано,",
        "Ведь этого недостаточно.",
        "Когда ночь уступает дорогу,",
        "Начинается очередной конец света.",
        "Чему быть, того не миновать,",
        "Любая река впадает в море,",
        "Но ее всегда мало.",
        "Когда ночь уступает дорогу,"
        };
        List<double> chisla = new List<double>();

        List<Animal> animals = new List<Animal>() {
            new Animal("Бобик", "Мопс", new DateTime(2005, 1, 1), "Серый"),
            new Animal("Шарик", "Лабрадор", new DateTime(2019, 1, 1), "Серый"),
            new Animal("Мариэль", "Пудель", new DateTime(2015, 1, 1), "Белый"),
            new Animal("Мориарти", "Шпиц", new DateTime(2022, 1, 1), "Белый"),
            new Animal("Сэм", "Питбуль", new DateTime(2023, 1, 1), "Рыжий"),
            new Animal("Картер", "Цвергшнауцер", new DateTime(2022, 1, 1), "Черный"),
            new Animal("Рыжик", "Лабрадор", new DateTime(1984, 1, 1), "Рыжий")
        };

        public MainWindow()
        {
            Random ran = new Random();
            InitializeComponent();
            for(int i = 0; i < 7; i++)
            {
                chisla.Add(ran.Next(50));
            }
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            //Min значение с помощью сортировки
            double min = chisla.OrderBy(p => p).ToList()[0];
            lw1.Items.Add($"Значения: {String.Join(" ", chisla)}\nМин значение: {min}");

            //Клички собак, старше 7-ми лет
            var zadaniye2 = animals.Where(p => DateTime.Today >= p.Year.AddYears(7));
            lw1.Items.Add($"\nКлички собак старше 7 лет:");
            foreach (Animal a in zadaniye2)
            {
                lw1.Items.Add(a.Name);
            }

            //Количество строк с 'ь'
            int count = Enumerable.Count(stroki, p => p.Contains('ь'));
            lw1.Items.Add($"\nКоличество строк с \'ь\': {count}") ;

            //Сумма четных чисел
            var sum = chisla.Where(p => p % 2 == 0).Sum();

            lw1.Items.Add($"\nСумма четных чисел: {sum}\n");

            //Сортировка списка по году рождения
            var zad5 = animals.OrderByDescending(p => p.Year);
            foreach (Animal a in zad5)
            {
                lw1.Items.Add($"{a.Name} Год рождения: {a.Year.Year}");
            }

            //Представители одной породы
            var zad6 = animals.Where(p => p.Poroda == "Лабрадор");
            lw1.Items.Add("\nЛабрадоры: ");
            foreach (Animal a in zad6)
            {
                lw1.Items.Add($"{a.Name} {a.Poroda}");
            }

            //Окрасы собак 2022 года
            var zad7 = animals.Where(p => p.Year.Year == 2022);
            lw1.Items.Add("\nОкрасы: ");
            foreach (Animal a in zad7)
            {
                lw1.Items.Add($"{a.Color}");
            }
        }
    }
}
