
using System;
using System.Windows.Forms;

namespace TagRemover
{
    class Log
    {
        /// <summary>
        /// Types used to define the type of Message (is used by the Log to determing if Message needs to be displayed).
        /// </summary>
        public enum Type { Add, Remove, Warning, Error, Work, Done, Save, Regex, Info };

        private RichTextBox myLog;
        private bool warning;
        private bool error;
        private bool work;
        private bool done;
        private bool add;
        private bool remove;
        private bool save;
        private bool regex;
        private bool info;

        /// <summary>
        /// get/set for Warning.
        /// </summary>
        public bool Warning
        {
            get
            {
                return warning;
            }

            set
            {
                warning = value;
            }
        }
        /// <summary>
        /// get/set for Error.
        /// </summary>
        public bool Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }
        /// <summary>
        /// get/set for Work.
        /// </summary>
        public bool Work
        {
            get
            {
                return work;
            }

            set
            {
                work = value;
            }
        }
        /// <summary>
        /// get/set for Done.
        /// </summary>
        public bool Done
        {
            get
            {
                return done;
            }

            set
            {
                done = value;
            }
        }
        /// <summary>
        /// get/set for Add.
        /// </summary>
        public bool Add
        {
            get
            {
                return add;
            }

            set
            {
                add = value;
            }
        }
        /// <summary>
        /// get/set for Remove.
        /// </summary>
        public bool Remove
        {
            get
            {
                return remove;
            }

            set
            {
                remove = value;
            }
        }
        /// <summary>
        /// get/set for Save.
        /// </summary>
        public bool Save
        {
            get
            {
                return save;
            }

            set
            {
                save = value;
            }
        }
        /// <summary>
        /// get/set for Regex.
        /// </summary>
        public bool Regex
        {
            get
            {
                return regex;
            }

            set
            {
                regex = value;
            }
        }
        /// <summary>
        /// get/set for Info.
        /// </summary>
        public bool Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        /// <summary>
        /// Constructor for Log.
        /// </summary>
        /// <param name="Log">Textbox in which the Logger writes.</param>
        /// <param name="warning">defines if warnings are printed (default true)</param>
        /// <param name="error">defines if errors are printed (default true)</param>
        /// <param name="work">defines if works are printed (default true)</param>
        /// <param name="done">defines if dones are printed (default true)</param>
        /// <param name="add">defines if adds are printed (default true)</param>
        /// <param name="remove">defines if removes are printed (default true)</param>
        public Log(RichTextBox Log,
            bool warning = true,
            bool error = true,
            bool work = true,
            bool done = true,
            bool add = true,
            bool remove = true,
            bool save = true,
            bool regex = true,
            bool info = true
            )
        {
            myLog = Log;
            this.warning = warning;
            this.error = error;
            this.work = work;
            this.done = done;
            this.add = add;
            this.remove = remove;
            this.save = save;
            this.regex = regex;
            this.info = info;
        }

        /// <summary>
        /// Writes to TextBox with the designated Tag.
        /// </summary>
        /// <param name="msg">Message to be printed.</param>
        /// <param name="type">Type of the message.</param>
        public void Append(String msg, Type type)
        {
            String tag = "";
            switch (type)
            {
                case Type.Warning:
                    {
                        if (warning == false) return;
                        tag = "[Warning]";
                        break;
                    }
                case Type.Error:
                    {
                        if (error == false) return;
                        tag = "[Error]";
                        break;
                    }
                case Type.Work:
                    {
                        if (work == false) return;
                        tag = "[Work]";
                        break;
                    }
                case Type.Done:
                    {
                        if (done == false) return;
                        tag = "[Done]";
                        break;
                    }
                case Type.Add:
                    {
                        if (add == false) return;
                        tag = "[Add]";
                        break;
                    }
                case Type.Remove:
                    {
                        if (remove == false) return;
                        tag = "[Remove]";
                        break;
                    }
                case Type.Save:
                    {
                        if (remove == false) return;
                        tag = "[Save]";
                        break;
                    }
                case Type.Regex:
                    {
                        if (remove == false) return;
                        tag = "[Regex]";
                        break;
                    }
                case Type.Info:
                    {
                        if (remove == false) return;
                        tag = "[Info]";
                        break;
                    }
                default: break;
            }

            myLog.AppendText(tag + " " + msg + "\n");
        }
    }
}