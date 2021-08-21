
//private void Form1_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F3)
//    {
//        Control control = this.FindFocusedControl(this);
//        if (control.GetType() == typeof(LookUpEdit) || control.Parent.GetType() == typeof(LookUpEdit))
//        {
//            LookUpEdit lue;
//            lue = control as LookUpEdit;
//            if (lue == null)
//            {
//                lue = control.Parent as LookUpEdit;
//            }
//            lue.Text = "BlaBlaBla";
//        }

//    }
//}
//public Control FindFocusedControl(Control control)
//{
//    ContainerControl container = control as ContainerControl;
//    while (container != null)
//    {
//        control = container.ActiveControl;
//        container = control as ContainerControl;
//    }
//    return control;
//}


//gridView1.Appearance.HideSelectionRow.Assign(gridView1.Appearance.FocusedRow); 

