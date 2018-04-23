# How to dynamically show or hide text within the preview panel


<p>This example demonstrates how to emulate content switching within rows' <a href="http://documentation.devexpress.com/#AspNet/CustomDocument3672">preview panel</a>. Initially, a preview displays an expand button and a label with short text of a long memo field. When the expand button is clicked, full text is displayed.</p><p>This functionality is implemented by changing visibility of controls within the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewGridViewTemplates_PreviewRowtopic">PreviewRow</a> template.</p><p>To avoid flickering, place the ASPxGridView within the AJAX UpdatePanel and set <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_EnableCallBackstopic">ASPxGridView.EnableCallBacks</a> to false.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E1385">How to hide template controls in individual cells</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2287">How to show long text in the PreviewRow using the ASPxCallback control</a></p>

<br/>


