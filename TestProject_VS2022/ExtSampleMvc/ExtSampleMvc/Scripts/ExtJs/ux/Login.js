/// <reference path="../Ext.js" />

Ext.define("Ext.ux.Login", {
    extend: "Ext.window.Window",
    singleton: true,
    title: 'ExtJs Mvc登录窗口',
    width: 450,
    height: 300,
    modal: true,
    closable: false,
    resizable: false,
    closeAction: 'hide',
    hideMode: 'offsets',

    initComponent: function () {
        var me = this;

        me.image = Ext.create(Ext.Img, {
            style: "cursor:pointer ",
            src: "/VerifyCode",
            listeners: {
                click: me.onRefrehImage,
                element: "el",
                scope: me
            }
        });

        me.form = Ext.create(Ext.form.Panel, {
            border: false,
            bodyPadding: 5,
            bodyStyle: "background:#DFE9F6",
            url: "Account/Login",
            defaultType: "textfield",
            fieldDefaults: {
                labelWidth: 80,
                labelSeparator: "：",
                anchor: "0",
                allowBlank: false
            },
            items: [
                {
                    fieldLabel: "用户名", name: "UserName"
                },
                {
                    fieldLabel: "密码", name: "Password", inputType: "password"
                },
                {
                    fieldLabel: "验证码", name: "Vcode", minLength: 4, maxLength: 4
                },
                {
                    xtype: "container", height: 80, anchor: "-5", layout: "fit",
                    items: [me.image]
                },
                {
                    xtype: "container", anchor: "-5", html: "**验证码不区分大小写，如果看不清楚验证码，可单击图片刷新验证码。"
                }
            ],
            dockedItems: [{
                xtype: 'toolbar', dock: 'bottom', ui: 'footer', layout: { pack: "center" },
                items: [
                    { text: "登录", width: 80, disabled: true, formBind: true, handler: me.onLogin, scope: me },
                    { text: "重置", width: 80, handler: me.onReset, scope: me }
                ]
            }]
        });

        me.items = [me.form]

        me.callParent(arguments);

    },

    onRefrehImage: function () {
        this.image.setSrc("/VerifyCode?_dc=" + (new Date()).getTime());
    },

    onReset: function () {
        var me = this;
        me.form.getForm().reset();
        if (me.form.items.items[0]) {
            me.form.items.items[0].focus(true, 10);
        }
        me.onRefrehImage();
    },

    onLogin: function () {
        var me = this,
            f = me.form.getForm();
        if (f.isValid()) {
            f.submit({
                //waitMsg: "正在登录，请等待……",
                //waitTitle: "正在登录",
                success: function (form, action) {
                    Ext.Msg.alert("提示信息", "登录成功!");
                    //window.location.reload();
                },
                failure: function () {
                    Ext.Msg.alert("提示信息", "登录失败!");
                },
                scope: me
            });
        }
    }


});