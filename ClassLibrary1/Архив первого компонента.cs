using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public partial class Архив_первого_компонента : Component
    {
        public Архив_первого_компонента()
        {
            InitializeComponent();
        }

        public Архив_первого_компонента(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        //        public class Value : EventArgs
        //        {
        //            public string Del { set; get; }
        //        }
        //        public class Mask : EventArgs
        //        {
        //            string maskString;
        //            string resultString;
        //            char newChar;
        //            int cursorPosition;
        //            char[] charMass;
        //            string userControlDeleteChoise;
        //            public string Masked
        //            {
        //                set
        //                {
        //                    maskString = value;
        //                    charMass = new char[maskString.Length];
        //                    charMass = maskString.ToCharArray();
        //                    resultString = new string(charMass);
        //                }// получаем текущее значение TextBox
        //                get
        //                {
        //                    return maskString;
        //                }

        //            }
        //            public int CursorPosition
        //            {
        //                set
        //                {
        //                    cursorPosition = value;
        //                }
        //                get
        //                {
        //                    return cursorPosition;
        //                }
        //            }
        //            public char NewChar
        //            {

        //                set
        //                {
        //                    int maskStringIndex = cursorPosition;
        //                    if (cursorPosition < maskString.Length)
        //                    {
        //                        newChar = value;
        //                        if (newChar >= '0' && newChar <= '9')
        //                        {

        //                            if (maskString[cursorPosition] == ' ' && charMass[cursorPosition] < '0')
        //                            {
        //                                charMass[cursorPosition] = newChar;


        //                            }
        //                            else
        //                            {
        //                                while (maskStringIndex < maskString.Length)
        //                                {
        //                                    if (maskString[maskStringIndex] != ' ' || charMass[maskStringIndex] >= '0')
        //                                        maskStringIndex++;
        //                                    else
        //                                    {
        //                                        charMass[maskStringIndex] = newChar;
        //                                        break;
        //                                    }

        //                                }
        //                                if (maskStringIndex < maskString.Length - 1)
        //                                    cursorPosition = maskStringIndex + 1;
        //                            }
        //                        }
        //                    }
        //                }
        //            }



        //            public string CharReplace
        //            {

        //                get
        //                {
        //                    if (newChar >= '0' && newChar <= '9')
        //                    {
        //                        char[] ResultMaskMass = maskString.ToCharArray();
        //                        for (int i = 0; i < maskString.Length; i++)
        //                        {
        //                            if (charMass[i] >= '0' && charMass[i] <= '9')
        //                                ResultMaskMass[i] = charMass[i];

        //                        }
        //                        cursorPosition++;
        //                        resultString = new string(ResultMaskMass);


        //                        while (cursorPosition < maskString.Length)//для курсора
        //                        {
        //                            if (maskString[cursorPosition] != ' ')
        //                                cursorPosition++;
        //                            else
        //                            {

        //                                break;
        //                            }

        //                        }
        //                    }
        //                    return resultString;
        //                }




        //            }

        //            public string Delete
        //            {

        //                get
        //                {


        //                    if (cursorPosition >= maskString.Length)
        //                        cursorPosition = maskString.Length - 1;
        //                    char[] ResultMass = resultString.ToCharArray();

        //                    if (resultString != null)
        //                        if (cursorPosition - 1 >= 0)
        //                        {
        //                            if (ResultMass[cursorPosition - 1] >= '0' && ResultMass[cursorPosition - 1] <= '9')
        //                            {
        //                                ResultMass[cursorPosition - 1] = ' ';
        //                                charMass[cursorPosition - 1] = ' ';
        //                                resultString = new string(ResultMass);
        //                                CursorPosition = cursorPosition - 1;

        //                            }
        //                            else
        //                                if (ResultMass[cursorPosition - 1] == ' ' || ResultMass[cursorPosition - 1] == '|')
        //                            {
        //                                cursorPosition--;
        //                                while (cursorPosition >= 0)//для курсора
        //                                {
        //                                    if ((ResultMass[cursorPosition] == ' ' || ResultMass[cursorPosition] == '|') && cursorPosition != 0)
        //                                        cursorPosition--;
        //                                    else
        //                                    {
        //                                        if (ResultMass[cursorPosition] >= '0' && ResultMass[cursorPosition] <= '9')
        //                                        {
        //                                            ResultMass[cursorPosition] = ' ';
        //                                            charMass[cursorPosition] = ' ';
        //                                            resultString = new string(ResultMass);


        //                                        }
        //                                        break;
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    return resultString;
        //                }
        //            }

        //            public int DataValid //-1 - действие не выполнено, 0 - false, 1 - true
        //            //Определяет валидность информации
        //            //TextComponent - главный источник текста, InfoComponent - компонент передающий пользователю информацию
        //            {
        //                get
        //                {

        //                    int ControlNumber;
        //                    if (resultString.IndexOf(" ") == -1 && resultString.IndexOf("\0") == -1) //проверяем, заполнены ли все ячейки
        //                                                                                             //начинаем проверку валидности контрольного числа
        //                    {
        //                        ControlNumber = int.Parse(charMass[3].ToString()) + int.Parse(charMass[5].ToString()) + int.Parse(charMass[7].ToString()) + int.Parse(charMass[11].ToString()) + int.Parse(charMass[13].ToString()) + int.Parse(charMass[15].ToString());
        //                        ControlNumber *= 3;
        //                        ControlNumber += int.Parse(charMass[0].ToString()) + int.Parse(charMass[4].ToString()) + int.Parse(charMass[6].ToString()) + int.Parse(charMass[8].ToString()) + int.Parse(charMass[12].ToString()) + int.Parse(charMass[14].ToString());
        //                        ControlNumber %= 10;
        //                        ControlNumber = 10 - ControlNumber;
        //                        if (ControlNumber == int.Parse(charMass[16].ToString())) //проверка соответствия контр.числа числу введеному пользователем

        //                            return 1;
        //                        else
        //                            return 0;

        //                    }
        //                    else
        //                        return -1;
        //                }
        //            }

        //            public string UserComponentDeleteEvent
        //            {
        //                set
        //                { userControlDeleteChoise = value; }
        //                get
        //                {
        //                    if (userControlDeleteChoise == "DeleteLastSymbol")
        //                        return Delete;
        //                    else
        //                    if (userControlDeleteChoise == "FullClear")
        //                    {
        //                        charMass = new Char[maskString.Length];
        //                        resultString = new string(charMass);
        //                        return Masked;
        //                    }
        //                    else
        //                        return "";
        //                }
    //    //            }
    //    //        }
    //    int localCursosPosition = cursorPosition;
    //                    if (charMass[16] == ' ') {
    //                    char newChar = value;

    //    char oldChar = ' ';
    //    bool charMassEnterTrigger = false; //необходим в той ситуации, когда во время перемещения позиции курсора, она зайдет внутрь числового предложения              
    //    bool OutterNumbers = false; //если за числами
    //    char[] ResultMass = resultString.ToCharArray();
    //                    if(localCursosPosition != 0)
    //                    if(!((ResultMass[localCursosPosition] >= '0' && ResultMass[localCursosPosition] <= '9')//cursor должен занять позицию справа от последнего числа, если изначально, он не был внутри чисел
    //                        || (ResultMass[localCursosPosition - 1] >= '0' && ResultMass[localCursosPosition - 1] <= '9'))&&
    //                        ResultMass[localCursosPosition] != '|')
    //                    for (int i = 0; i<ResultMass.Count(); i++) 
    //                    {//перебираем массив, дабы найти индекс последнего числа
    //                        if (ResultMass[i] >= '0' && ResultMass[i] <= '9')
    //                                    localCursosPosition = i;
    //                                OutterNumbers = true;   
    //                    }
    //int lastSymbolIndex = 0;
    ////    while (cursorPosition >= 0 || charMass[cursorPosition] == '|' || ResultMass[cursorPosition] == ' ')//cursor должен ехать влево
    ////{
    ////    if ((ResultMass[cursorPosition] == ' ' || ResultMass[cursorPosition] == '|') && cursorPosition != 0)
    ////    {
    ////        cursorPosition--;
    //        if (ResultMass[cursorPosition] != ' ' && ResultMass[cursorPosition] != '|')
    //            charMassEnterTrigger = true;
    //    }
    //    else
    //    {
    //        break; //срабатывает в любом случае, было использование перемещения по массиву или нет
    //    }

    //    if (charMassEnterTrigger == true)
    //    {
    //        cursorPosition++;
    //        break;

    //    }
    //}
    //int maskStringIndex = localCursosPosition;
    //                    if (localCursosPosition<ResultMass.Length)
    //                    {

    //                        if (newChar >= '0' && newChar <= '9')
    //                        {

    //                            while (localCursosPosition<ResultMass.Length) //перемещаемся вперед, дабы перейти на позицию дозвеленную маской                                
    //                                if (ResultMass[localCursosPosition] != ' ' && OutterNumbers == true)
    //                                {
    //                                    localCursosPosition++;
    //                                    lastSymbolIndex = localCursosPosition;
    //                                }
    //                                else
    //                                    break;

    //                            for (int i = localCursosPosition; i<ResultMass.Length; i++)
    //                            {


    //                                if (i == localCursosPosition)
    //                                {
    //                                    oldChar = ResultMass[i];
    //                                    charMass[i] = newChar;
    //                                    newChar = oldChar;
    //                                }
    //                                if (i != localCursosPosition)
    //                                    if (ResultMass[i] != '|')
    //                                    {
    //                                        oldChar = ResultMass[i];
    //                                        charMass[i] = newChar;
    //                                        newChar = oldChar;
    //                                    }
    //                                    else
    //                                    if (i >= lastSymbolIndex)
    //                                        break;
    //                                    else
    //                                    {
    //                                        while (i<ResultMass.Length) //перемещаемся вперед, дабы перейти на позицию дозвеленную маской
    //                                        {
    //                                            if (ResultMass[i] != ' ')
    //                                                i++;
    //                                            else
    //                                                break;

    //                                        }
    //                                        charMass[i] = newChar;
    //                                        break;
    //                                    }
    //                            }                                                         
    //                        }
    //                        localCursosPosition++;
    //                        cursorPosition = localCursosPosition;
    //                    }
    //                }
    }
}
