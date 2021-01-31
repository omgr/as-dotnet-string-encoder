using System;
using System.Collections.Generic;
using System.Linq;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {

            message = message.ToLower(); //making string case insensitive.
            string encodedString = ""; //resultant encoded string is populated here
            Dictionary<char, string> vowelAndSpaceRules = new Dictionary<char, string>
                                                                { { 'a', "1" },
                                                                  { 'e', "2" },
                                                                  { 'i', "3" },
                                                                  { 'o', "4" },
                                                                  { 'u', "5" },
                                                                  { 'y', " " },
                                                                  { ' ', "y" }
                                                                };
            for (int i = 0; i < message.Length; i++)
            {

                if (vowelAndSpaceRules.Keys.Contains(message[i]))
                {
                    //replaces all the vowels, spaces and charecter 'y' with encoding charecters.
                    encodedString = encodedString + vowelAndSpaceRules[message[i]];
                }
                else if (char.IsDigit(message[i]))
                {
                    //once a digit is encountered, tracks all the digits and revers them as part of encoding.
                    string num = "";
                    while (i < message.Length && char.IsDigit(message[i]))
                    {
                        num = num + message[i].ToString();
                        i++;
                    }
                    encodedString = encodedString + String.Join("", num.Reverse().ToArray());
                    i--;
                }
                else
                {
                    //finally, for rest of the charecters, 
                    //if it is a alphabet, it's previous letter would be pushed to encoded string 
                    //otherwise same charecter is pushed.
                    if (char.IsLetter(message[i]))
                    {
                        int ascii = (int)Convert.ToChar(message[i]);
                        ascii = ascii - 1;
                        char encodedChar = (char)ascii;
                        encodedString = encodedString + encodedChar;

                    }
                    else
                    {
                        encodedString = encodedString + message[i];
                    }
                }

            }
            return encodedString;
        }
    }
}