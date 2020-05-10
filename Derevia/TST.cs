using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derevia
{
    class TST
    {
        public classLeaf cRoot;

        char chrNull = '\0';

        int index = 1;

       int scc = 0;

        public TST()

        {           

            cRoot = new classLeaf(chrNull);

        }

        public void Insert2(ref classLeaf cLeaf, string strWord)

        {

            if (strWord[0] > cLeaf.chr)

            {

                if (cLeaf.down != null)

                {

                    if (strWord.Length == 2)

                    {

                        classLeaf cIndex = new classLeaf(index);

                        cLeaf.index = index;

                        index++;

                    }

                    Insert2(ref cLeaf.down, strWord);

                }

                else

                {

                    classLeaf cDown = new classLeaf(strWord[0]);

                    cLeaf.down = cDown;

                    if (strWord.Length > 1)

                        Insert2(ref cDown, strWord);

                }

            }

            else if (strWord[0] < cLeaf.chr)

            {

                if (cLeaf.up != null)

                    Insert2(ref cLeaf.up, strWord);

                else

                {

                    classLeaf cUp = new classLeaf(strWord[0]);

                    cLeaf.up = cUp;

                    if (strWord.Length > 1)

                        Insert2(ref cUp, strWord);

                }

            }

            else if (strWord[0] == cLeaf.chr)

            {

                if (strWord.Length > 1)

                {

                    if (cLeaf.next != null)

                    {

                        if (strWord.Length == 2)

                        {

                            classLeaf cIndex = new classLeaf(index);

                            cLeaf.index = index;

                            index++;

                        }

                        Insert2(ref cLeaf.next, strWord.Substring(1));                
                     }



                    else

                    {

                        classLeaf cNext = new classLeaf(strWord[1]);

                        cLeaf.next = cNext;

                        if (strWord.Length == 2)

                        {

                            classLeaf cIndex = new classLeaf(index);

                            cLeaf.index = index;

                            index++;

                        }

                        Insert2(ref cNext, strWord.Substring(1));

                    }

                }

            }

        }

        public int Search2(ref classLeaf cLeaf, string strWord)

        {

            if (strWord[0] > cLeaf.chr)

            {

                if (cLeaf.down != null)

                    return Search2(ref cLeaf.down, strWord);

                else

                    return 0;

            }

            else if (strWord[0] < cLeaf.chr)

            {

                if (cLeaf.up != null)

                    return Search2(ref cLeaf.up, strWord);

                else

                    return 0;

            }

            else if (strWord[0] == cLeaf.chr)

            {

                if ((strWord.Length == 1) && (cLeaf.index > 0))

                {

                    return 1;

                }

                else if ((strWord.Length == 1) && (cLeaf.index == 0))

                    return 0;

                else

                    return Search2(ref cLeaf.next, strWord.Substring(1));

            }

            return 0;

        }

        private void traverseTree(ref classLeaf cLeaf, ref string[] strWords, string strThisWord)

        {

            if (cLeaf.up != null)

                traverseTree(ref cLeaf.up, ref strWords, strThisWord);

            string strExtendedWord = strThisWord + cLeaf.chr.ToString();

            if (cLeaf.chr == chrNull)

            {

                Array.Resize<string>(ref strWords, strWords.Length + 1);

                strWords[strWords.Length - 1] = strExtendedWord;

            }

            else

            if (cLeaf.next != null)

                traverseTree(ref cLeaf.next, ref strWords, strExtendedWord);

            if (cLeaf.down != null)

                traverseTree(ref cLeaf.down, ref strWords, strThisWord);

        }

        private void deleteWord(ref classLeaf cLeaf, string strWord)

        {

            if (scc != 0)

            {

                if ((cLeaf.down != null) || (cLeaf.next != null))

                {

                    if ((cLeaf.down != null) && (cLeaf.index == 0) && (strWord.Length != 0))

                    {

                        deleteWord(ref cLeaf.down, strWord.Substring(1));

                    }

                    if ((cLeaf.next != null) && (cLeaf.index == 0) && (strWord.Length != 0))

                    {

                        deleteWord(ref cLeaf.next, strWord.Substring(1));

                    }

                    cLeaf.down = null;

                    cLeaf.up = null;

                    cLeaf.next = null;

                    cLeaf.index = 0;

                }

            }

            scc++;

        }

        public int Delete2(string vvod_slova_na_ydalenie)

        {

            index = 1;

            string[] strWords = new string[0];

            traverseTree(ref cRoot, ref strWords, "");

            var list = strWords.Cast<string>().ToList();

            string slovo_ydalenie = vvod_slova_na_ydalenie + "\0";

            string userRem = list.FirstOrDefault(us => us == slovo_ydalenie);

            foreach (string s in strWords)

                deleteWord(ref cRoot, s);

            int delete = 0;

            if (userRem != null)

            {

                delete = 1;

                list.Remove(userRem);

            }

            //cmbWords.DataSource = list;

            strWords = new string[list.Count];

            for (int i = 0; i < list.Count; i++)

            {

                strWords[i] = list[i];

            }

            foreach (string s in strWords)

            {

                Insert2(ref cRoot, s);

            }

            return delete;

        }
    }


    public class classLeaf

    {

        public classLeaf down;

        public classLeaf up;

        public classLeaf next;

        public int index;

        public char chr;

        public classLeaf(char c)

        {

            chr = c;

        }

        public classLeaf(int i)

        {

            index = i;

        }

    }
}
