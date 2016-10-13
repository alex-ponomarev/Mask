using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace ClassLibrary1
{//Создать компонент, дочерний TextBox
   //преподаватель Юрий Викторович
    public class MathMetods
    {
        public void DataValid(TextBox TextComponent, TextBox InfoComponent)
        //Определяет валидность информации
        //TextComponent - главный источник текста, InfoComponent - компонент передающий пользователю информацию
        {
            bool ChangeColorEvent = false;
            string TempText = TextComponent.Text;
            char[] CharMas = TempText.ToCharArray();
            int ControlNumber;
            if (TempText.IndexOf("") != -1) //проверяем, заполнена ли все ячейки
                ChangeColorEvent = true;
            if (ChangeColorEvent == true) //начинаем проверку валидности контрольного числа
            {
                ControlNumber = int.Parse(CharMas[3].ToString()) + int.Parse(CharMas[5].ToString()) + int.Parse(CharMas[7].ToString()) + int.Parse(CharMas[11].ToString()) + int.Parse(CharMas[13].ToString()) + int.Parse(CharMas[15].ToString());
                ControlNumber *= 3;
                ControlNumber += int.Parse(CharMas[0].ToString()) + int.Parse(CharMas[4].ToString()) + int.Parse(CharMas[6].ToString()) + int.Parse(CharMas[8].ToString()) + int.Parse(CharMas[12].ToString()) + int.Parse(CharMas[14].ToString());
                ControlNumber %= 10;
                ControlNumber = 10 - ControlNumber;
                if (ControlNumber == int.Parse(CharMas[16].ToString())) //проверка соответствия контр.числа числу введеному пользователем
                {
                    InfoComponent.Text = "Контрольные числа верны";
                    InfoComponent.BackColor = Color.LightGreen;
                }
                if (ControlNumber != int.Parse(CharMas[16].ToString()))
                {
                    InfoComponent.Text = "Контрольные числа  не верны";
                    InfoComponent.BackColor = Color.LightPink;
                }
            }
        }
        public void NoticeRaplace(int valid, TextBox InfoComponent)
        //Определяет валидность информации
        //TextComponent - главный источник текста, InfoComponent - компонент передающий пользователю информацию
        {
            if (valid == 1) //проверка соответствия контр.числа числу введеному пользователем
            {
                InfoComponent.Text = "Контрольные числа верны";
                InfoComponent.BackColor = Color.LightGreen;
            }
            if (valid == 0)
            {
                InfoComponent.Text = "Контрольные числа  не верны";
                InfoComponent.BackColor = Color.LightPink;
            }
            if (valid == -1)
            {
                InfoComponent.Text = "Введите штрих-код";
                InfoComponent.BackColor = Color.LightGray;
            }
        }

       public void SymbolChange(TextBox TextComponent, UserControl1.Number e) //замена символов по маске
        {
    
            string TempText = TextComponent.Text;
            char[] CharMas = TempText.ToCharArray();
            int ИндексСимвола = TextComponent.Text.IndexOf(" "); //Первое вхождение пробела в строку
            if (ИндексСимвола > -1)
            {
                CharMas[ИндексСимвола] = char.Parse(e.Num.ToString());
                TempText = new string(CharMas);
                TextComponent.Text = TempText;
            }
        }
        public void SymbolChange(TextBox TextComponent, char e) //замена символов по маске через клавиатуру
        {

            string TempText = TextComponent.Text;
            char[] CharMas = TempText.ToCharArray();
            int ПозицияКурсора = TextComponent.SelectionStart;
            int ИндексСимвола = TextComponent.Text.IndexOf(" "); //Первое вхождение пробела в строку
            if (e >= '0' && e <= '9')
            {
                if (CharMas[ПозицияКурсора] == ' ' || CharMas[ПозицияКурсора] >= '0' && CharMas[ПозицияКурсора] <= '9')
                {

                    CharMas[ПозицияКурсора] = e;
                    TempText = new string(CharMas);
                    TextComponent.Text = TempText;
                    
                        TextComponent.SelectionStart = ПозицияКурсора + 1;

                }
                else
            if (ИндексСимвола > -1)
                {
                    CharMas[ИндексСимвола] = e;
                    TempText = new string(CharMas);
                    TextComponent.Text = TempText;
                    
                        TextComponent.SelectionStart = ИндексСимвола + 1;
                }
            }
        }
        public void DeleteEvent(TextBox TextComponent, char e) //замена символов по маске
        {

            String TempText = TextComponent.Text;
            char[] CharMas = TempText.ToCharArray();
            int ПозицияКурсора = TextComponent.SelectionStart;

            if (ПозицияКурсора - 1 >= 0)
            {
                if (TempText[ПозицияКурсора - 1] >= '0' && TempText[ПозицияКурсора - 1] <= '9')
                {
                    CharMas[ПозицияКурсора - 1] = ' ';
                    TempText = new string(CharMas);
                    TextComponent.Text = TempText;
                    TextComponent.SelectionStart = ПозицияКурсора - 1;
                }
                else 
                    if(TempText[ПозицияКурсора - 1] == ' ' || TempText[ПозицияКурсора - 1] == '|')
                    TextComponent.SelectionStart = ПозицияКурсора - 1;
            }
            
               
            
        }
        public void DeleteEvent(TextBox TextComponent, TextBox InfoComponent, UserControl1.Clearing e)
        {
 
            int Index = -1;
            String TempText = TextComponent.Text;
            char[] CharMas = TempText.ToCharArray();
            if (e.ClearVariants == "DeleteLastSymbol")
            {
                for (int i = TempText.Length - 1; i > -1; i--)
                    if (TempText[i] >= '0' && TempText[i] <= '9')
                    {
                        Index = i;
                        break;
                    }
                if (Index > -1)
                {
                    CharMas[Index] = ' ';
                    TempText = new string(CharMas);
                    TextComponent.Text = TempText;
                }
            }
            if (e.ClearVariants == "FullClear")
            {
                for (int i = TempText.Length - 1; i > -1; i--)
                    if (TempText[i] >= '0' && TempText[i] <= '9')
                    {
                        CharMas[i] = ' ';
                    }

                TempText = new string(CharMas);
                TextComponent.Text = TempText;
                InfoComponent.Text = "Введите штрих-код";
                InfoComponent.BackColor = Color.LightGray;
            }

        }

    }
}
