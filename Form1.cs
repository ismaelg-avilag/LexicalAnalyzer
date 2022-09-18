namespace LexicalAnalyzer
{
    public partial class Form1 : Form
    {
        List<Element> elements;

        public Form1()
        {
            InitializeComponent();
            elements = new List<Element>();
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            List<string> strings = new List<string>();

            for(int i=0; i<textBoxInput.Lines.Length; i++)
                strings.Add(textBoxInput.Lines[i] + "$");

            for (int i = 0; i < strings.Count; i++)
                analyze(strings[i]);
        }

        void analyze(string s)
        {
            int state = 0;
            string lexeme = "", token = "error";

            for(int i=0; i<s.Length; i++) {
                switch(state) {
                    case 0:
                        if(s[i] == ' ')
                            state = 0;
                        else if(Char.IsLetter(s[i]) || s[i] == '_') {
                            state = 1;
                            lexeme += s[i];
                            token = "id";
                        }
                        else if(s[i] == ';') {
                            state = 2;
                            lexeme += s[i];
                            token = "Punto y coma";
                        }
                        else if(s[i] == '$') {
                            state = 3;
                            lexeme += s[i];
                            token = "Pesos";
                        }
                        else if(s[i] == '=') {
                            state = 1;
                            lexeme += s[i];
                            token = "Igual";
                        }
                        else if(Char.IsDigit(s[i])) {
                            state = 5;
                            lexeme += s[i];
                            token = "Numero";
                        }
                        break;

                    case 1:
                        if(Char.IsDigit(s[i]) || Char.IsLetter(s[i]) || s[i] == '_') {
                            state = 1;
                            lexeme += s[i];
                            token = "id";
                        }
                        else if(s[i] == '=') {
                            state = 4;
                            lexeme += s[i];
                            token = "Op relacional";
                        }
                        else
                            state = 20;
                        break;

                    case 2:
                        state = 20;
                        break;

                    case 3:
                        state = 20;
                        break;

                    case 4:
                        state = 20;
                        break;

                    case 5:
                        if(Char.IsDigit(s[i])) {
                            state = 5;
                            lexeme += s[i];
                            token = "Tipo de dato";
                        }
                        else if(s[i] == '.') {
                            state = 6;
                            lexeme += s[i];
                            token = "Tipo de dato";
                        }
                        else
                            state = 20;
                        break;

                    case 6:
                        if(Char.IsDigit(s[i])) {
                            state = 6;
                            lexeme += s[i];
                            token = "Tipo de dato";
                        }
                        else 
                            state = 20;
                        break;

                    case 20:
                        // Agregar el lexema encontrado y el token a la lista de elementos
                        break;
                }
            }

            
        }



    }
}