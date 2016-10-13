using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public partial class Component1 : Component
    {
        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public class Value : EventArgs
        {
            public string Del { set; get; }
        }
        public class Mask : EventArgs
        {
            string maskString;
            string symbolsString;
            string resultString;
            bool enterToSymbolsString = false;
            int cursorPosition;
            char[] charMass;
            int countOfAllNoneReadSymbols = 0;
            string userControlDeleteChoise;
            public string Masked
            {
                set
                {
                    maskString = value;
                    charMass = new char[maskString.Length];
                    charMass = maskString.ToCharArray();
                    resultString = new string(charMass);
                    symbolsString = "";
                    for (int i = 0; i < maskString.Length; i++)
                        if (maskString[i] == '|')
                            countOfAllNoneReadSymbols++;
                }// получаем текущее значение TextBox
                get
                {
                    return maskString;
                }

            }
            public int CursorPosition
            {
                set
                {
                    cursorPosition = value;
                }
                get
                {
                    return cursorPosition;
                }
            }
            public char NewChar
            {


                set
                {
                    if (value >= '0' && value <= '9')
                    {
                        if (symbolsString.Length != maskString.Length - countOfAllNoneReadSymbols)
                        {
                            int countOfMaskReadOnlySymbols = 0;//количество неизменяемых символов в маске
                            string symbolsStringLeft;
                            string symbolsStringRight;

                            for (int i = 0; i < cursorPosition; i++)
                                if (maskString[i] == '|')
                                    countOfMaskReadOnlySymbols++;


                            if (symbolsString.Length > 0)
                                if (cursorPosition - countOfMaskReadOnlySymbols <= symbolsString.Length - 1) //если курсор над числом
                                {
                                    symbolsStringLeft = symbolsString.Substring(0, cursorPosition - countOfMaskReadOnlySymbols) + value;
                                    symbolsStringRight = symbolsString.Substring(cursorPosition - countOfMaskReadOnlySymbols);
                                    symbolsString = symbolsStringLeft + symbolsStringRight;
                                    enterToSymbolsString = true;
                                }
                                else //если перед числом
                                {
                                    symbolsString += value;
                                    enterToSymbolsString = false;
                                }
                            if (symbolsString.Length == 0) //для первого значения
                            {
                                symbolsString += value;
                                enterToSymbolsString = false;
                            }
                        }
                    }
                }
            }


            public string CharReplace
            {

                get
                {
                 

                    char[] resultMass = maskString.ToCharArray(); 
                    int indexForSymbolsString = 0;
                    int indexForMaskString = 0;
                    while (indexForMaskString < maskString.Length) //процесс вставки символов по маске
                    {
                        if (maskString[indexForMaskString] == ' ')
                        {
                            if (indexForSymbolsString >= symbolsString.Length)
                                break;
                            else
                            {
                                resultMass[indexForMaskString] = symbolsString[indexForSymbolsString];
                                indexForSymbolsString++;
                                indexForMaskString++;
                            }
                        }
                        else
                            indexForMaskString++;
                    }


                    if (enterToSymbolsString == false) //если курсор не входил в массив чисел
                     //cursorPosition = countOfMaskReadOnlySymbols + symbolsString.Length; //то ставим его в конец этого массива
                        cursorPosition = indexForMaskString;                                 
                        resultString = new string(resultMass);
                        return resultString;
                }




            }

            public string Delete
            {

                get
                {
                    if(cursorPosition>0)
                    {
                        while (cursorPosition > 0)
                            if (maskString[cursorPosition - 1] == '|')
                                cursorPosition--;
                            else
                                break;
                    bool NoolJumpReady = false;
                    int countOfMaskReadOnlySymbols = 0;//количество неизменяемых символов в маске
                    string symbolsStringLeft = "";
                    string symbolsStringRight = "";
                    char[] resultMass = maskString.ToCharArray();
                    int indexForSymbolsString = 0;
                    int indexForMaskString = 0;
                    if (cursorPosition == 1)
                        NoolJumpReady = true;
                    for (int i = 0; i < cursorPosition; i++) //позволяет определить, находимся ли мы перед числами
                        if (maskString[i] == '|')
                            countOfMaskReadOnlySymbols++;
                    if (cursorPosition - countOfMaskReadOnlySymbols >= symbolsString.Length)
                    {

                        while (indexForMaskString < resultString.Length) //процесс определения конца строки
                        {
                            if (maskString[indexForMaskString] == ' ')
                            {
                                if (indexForSymbolsString >= symbolsString.Length)
                                    break;
                                else
                                {
                                    indexForSymbolsString++;
                                    indexForMaskString++;
                                    if (symbolsString.Length == indexForSymbolsString)
                                        cursorPosition = indexForMaskString;
                                }
                            }
                            else
                                indexForMaskString++;
                        }
                    }

                    indexForSymbolsString = 0;
                    indexForMaskString = 0;
                    countOfMaskReadOnlySymbols = 0;

                    if (symbolsString.Length > 0)
                    {

                        for (int i = 0; i < cursorPosition; i++)
                            if (maskString[i] == '|')
                                countOfMaskReadOnlySymbols++;

                        symbolsStringLeft = symbolsString.Substring(0, cursorPosition - countOfMaskReadOnlySymbols - 1);//-1 в конце второго параметра как раз и отвечает за удаление                 
                        symbolsStringRight = symbolsString.Substring(cursorPosition - countOfMaskReadOnlySymbols);
                        symbolsString = symbolsStringLeft + symbolsStringRight;

                        while (indexForMaskString < maskString.Length) //процесс вставки символов по маске
                        {
                            if (maskString[indexForMaskString] == ' ')
                            {
                                if (indexForSymbolsString >= symbolsString.Length)
                                    break;
                                else
                                {
                                    resultMass[indexForMaskString] = symbolsString[indexForSymbolsString];
                                    indexForSymbolsString++;
                                    indexForMaskString++;
                                    if (symbolsStringLeft.Length == indexForSymbolsString)
                                        cursorPosition = indexForMaskString;
                                }
                            }
                            else
                                indexForMaskString++;
                        }
                        if (NoolJumpReady == true)
                            cursorPosition = 0;                      

                        resultString = new string(resultMass);
                        return resultString;

                    }
                }
                    return resultString;
                }
            }

            public int DataValid //-1 - действие не выполнено, 0 - false, 1 - true
            //Определяет валидность информации
            //TextComponent - главный источник текста, InfoComponent - компонент передающий пользователю информацию
            {
                get
                {

                    int ControlNumber;
                    if (resultString.IndexOf(" ") == -1 && resultString.IndexOf("\0") == -1) //проверяем, заполнены ли все ячейки
                                                                                             //начинаем проверку валидности контрольного числа
                    {
                        char[] ResultMass = resultString.ToCharArray();
                        ControlNumber = int.Parse(ResultMass[3].ToString()) + int.Parse(ResultMass[5].ToString()) + int.Parse(ResultMass[7].ToString()) + int.Parse(ResultMass[11].ToString()) + int.Parse(ResultMass[13].ToString()) + int.Parse(ResultMass[15].ToString());
                        ControlNumber *= 3;
                        ControlNumber += int.Parse(ResultMass[0].ToString()) + int.Parse(ResultMass[4].ToString()) + int.Parse(ResultMass[6].ToString()) + int.Parse(ResultMass[8].ToString()) + int.Parse(ResultMass[12].ToString()) + int.Parse(ResultMass[14].ToString());
                        ControlNumber %= 10;
                        ControlNumber = 10 - ControlNumber;
                        if (ControlNumber == int.Parse(ResultMass[16].ToString())) //проверка соответствия контр.числа числу введеному пользователем

                            return 1;
                        else
                            return 0;

                    }
                    else
                        return -1;
                }
            }

            public string UserComponentDeleteEvent
            {
                set
                { userControlDeleteChoise = value; }
                get
                {
                    if (userControlDeleteChoise == "DeleteLastSymbol")
                        return Delete;
                    else
                    if (userControlDeleteChoise == "FullClear")
                    {
                        resultString = maskString;
                        symbolsString = "";
                        return Masked;
                    }
                    else
                        return "";
                }
            }
        }
    }
}
