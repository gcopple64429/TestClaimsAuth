using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;

namespace TestClaimsAuth
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {




            int count = Convert.ToInt32(TextBox1.Text);

            foreach (ListItem lst in CheckBoxList1.Items)
            {
                string lstValue = lst.Value;
                if (lst.Selected)
                {
                    if (lstValue == "textbox")
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            int tbID = i;
                            int lblID = i;
                            CreateControl("lblQuestion", lblID, lstValue, "before", i);
                            CreateControl("txtAnswer", tbID, lstValue, "before", i + 1);

                        }

                    }

                    if (lstValue == "radio")
                    {
                        int lblID = count;
                        CreateControl("lblQuestion", lblID, lstValue, "before", lblID);
                        for (int i = 1; i <= count; i++)
                        {
                            int rdbID = rtsc1.Controls.OfType<RadioButton>().ToList().Count;
                            CreateControl("rdbAnswer", rdbID, lstValue, "after", i);
                        }
                    }

                    if (lstValue == "check")
                    {

                        int lblID = count;
                        CreateControl("lblQuestion", lblID, lstValue, "before", lblID);
                        for (int i = 1; i <= count; i++)
                        {
                            int chkID = rtsc1.Controls.OfType<CheckBox>().ToList().Count;
                            CreateControl("chkAnswer", chkID, lstValue, "after", i);


                        }
                    }
                }
            }
        }

        private void CreateControl(string name, int id, string ctlType, string place, int count)
        {
            TextBox txt = new TextBox();
            Label lbl = new Label();
            RadioButton rdb = new RadioButton();
            CheckBox chk = new CheckBox();
            if (ctlType == "textbox")
            {
                txt.ID = name + id;
                lbl.ID = name + id;
                lbl.Text = "Question " + id + ":";
                if (name != "txtAnswer")
                {
                    rtsc1.Controls.Add(lbl);
                }
                else
                {
                    rtsc1.Controls.Add(txt);
                    Setprompt(txt);
                    Literal lt = new Literal();

                    lt.Text = "<br /><br />";

                    rtsc1.Controls.Add(lt);
                }
            }
            if (ctlType == "radio")
            {
                if (place == "before")
                {
                    lbl.ID = name + id;
                    lbl.Text = "Question " + id + ":";
                    rtsc1.Controls.Add(lbl);
                }
                if (place == "after" && id != count)
                {
                    rdb.ID = name + id;
                    rtsc1.Controls.Add(rdb);
                }
                if (place == "after" && id == count)
                {
                    Literal lt = new Literal();
                    lt.Text = "<br />";
                    rtsc1.Controls.Add(lt);
                }

            }
            if (ctlType == "check")
            {
                if (place == "before")
                {
                    lbl.ID = name + id;
                    lbl.Text = "Question " + id + ":";
                    rtsc1.Controls.Add(lbl);
                }
                if (place == "after" && id != count)
                {
                    chk.ID = name + id;
                    rtsc1.Controls.Add(chk);
                }
                if (place == "after" && id == count)
                {
                    Literal lt = new Literal();
                    lt.Text = "<br />";
                    rtsc1.Controls.Add(lt);
                }
            }
        }
        public string ControlRenderer(Control control)
        {
            StringWriter writer = new StringWriter();
            control.RenderControl(new HtmlTextWriter(writer));
            return writer.ToString();
        }
        private void Setprompt(TextBox txt)
        {
            string onFocusAction = "if (this.value == \"{0}\") {{ this.value = \"\"; this.style.color = \"black\"; }} ";
            string onBlurAction = " if (this.value == \"\") {{ this.value = \"{0}\"; this.style.color = \"gray\"; }} else this.style.color = \"black\";";
            onBlurAction = string.Format(onBlurAction, txt.Text);
            onFocusAction = string.Format(onFocusAction, txt.Text);
            txt.Attributes["onblur"] = onBlurAction;
            txt.Attributes["onfocus"] = onFocusAction;

        }



    }
}



