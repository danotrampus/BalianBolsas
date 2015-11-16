Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        'Css Global
        bundles.Add(New StyleBundle("~/Content/global/css").Include(
            "~/Content/global/plugins/font-awesome/css/font-awesome.css",
            "~/Content/global/plugins/simple-line-icons/simple-line-icons.css",
            "~/Content/global/plugins/bootstrap/css/bootstrap.css",
            "~/Content/global/plugins/uniform/css/uniform.default.css",
            "~/Content/global/plugins/bootstrap-switch/css/bootstrap-switch.css"))

        'Css Login
        bundles.Add(New StyleBundle("~/Content/login/css").Include(
            "~/Content/admin/pages/css/login2.css"))

        'Css Select2
        bundles.Add(New StyleBundle("~/Content/select2/css").Include(
            "~/Content/global/plugins/select2/select2.css"))

        'Css Multi-select
        bundles.Add(New StyleBundle("~/Content/multi-select/css").Include(
            "~/Content/global/plugins/jquery-multi-select/css/multi-select.css"))

        'Css Theme
        bundles.Add(New StyleBundle("~/Content/theme/css").Include(
            "~/Content/global/css/components-md.css",
            "~/Content/global/css/plugins-md.css",
            "~/Content/admin/layout/css/layout.css",
            "~/Content/admin/layout/css/themes/darkblue.css",
            "~/Content/admin/layout/css/custom.css"))

        'Css Datatables
        bundles.Add(New StyleBundle("~/Content/datatables/css").Include(
            "~/Content/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css"))

        'Css zTree
        bundles.Add(New StyleBundle("~/Content/ztree/css").Include(
            "~/Content/global/plugins/zTree/ztree.css"))

        'Css Summernote
        bundles.Add(New StyleBundle("~/Content/summernote/css").Include(
            "~/Content/global/plugins/bootstrap-summernote/summernote.css"))

        'Css DatePicker
        bundles.Add(New StyleBundle("~/Content/datepicker/css").Include(
            "~/Content/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.css"))

        'Css Star-Rating
        bundles.Add(New StyleBundle("~/Content/star-rating/css").Include(
            "~/Content/global/plugins/bootstrap-star-rating/css/star-rating.css"))

        'Css Error
        bundles.Add(New StyleBundle("~/Content/error/css").Include(
            "~/Content/admin/pages/css/error.css"))


        'Js Global
        bundles.Add(New ScriptBundle("~/Content/global/js").Include(
            "~/Content/global/plugins/jquery.js",
            "~/Content/global/plugins/jquery-migrate.js",
            "~/Content/global/plugins/jquery-ui/jquery-ui.js",
            "~/Content/global/plugins/bootstrap/js/bootstrap.js",
            "~/Content/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js",
            "~/Content/global/plugins/jquery-slimscroll/jquery.slimscroll.js",
            "~/Content/global/plugins/jquery.blockui.js",
            "~/Content/global/plugins/jquery.cokie.js",
            "~/Content/global/plugins/uniform/jquery.uniform.js",
            "~/Content/global/plugins/bootstrap-switch/js/bootstrap-switch.js",
            "~/Content/global/plugins/jquery-validation/js/jquery.validate.js"))

        'Js Theme
        bundles.Add(New ScriptBundle("~/Content/theme/js").Include(
            "~/Content/global/scripts/metronic.js",
            "~/Content/admin/layout/scripts/layout.js"))

        'Js Login
        bundles.Add(New ScriptBundle("~/Content/login/js").Include(
            "~/Content/admin/pages/scripts/login.js"))

        'Js Select2
        bundles.Add(New ScriptBundle("~/Content/select2/js").Include(
            "~/Content/global/plugins/select2/select2.js"))

        'Js Multi-select
        bundles.Add(New ScriptBundle("~/Content/multi-select/js").Include(
            "~/Content/global/plugins/jquery-multi-select/js/jquery.multi-select.js"))

        'Js Datatables
        bundles.Add(New ScriptBundle("~/Content/datatables/js").Include(
            "~/Content/global/plugins/datatables/media/js/jquery.dataTables.js",
            "~/Content/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"))

        'Js zTree
        bundles.Add(New ScriptBundle("~/Content/ztree/js").Include(
            "~/Content/global/plugins/ztree/jquery.ztree.js"))

        'Js GMaps
        bundles.Add(New ScriptBundle("~/Content/gmaps/js").Include(
            "~/Content/global/plugins/gmaps/gmaps.js"))

        'Js SignalR
        bundles.Add(New ScriptBundle("~/Content/signalr/js").Include(
            "~/Scripts/jquery.signalR-2.2.0.js"))

        'Js Chat
        bundles.Add(New ScriptBundle("~/Content/chat/js").Include(
            "~/Content/admin/layout/scripts/quick-sidebar.js"))

        'Js Summernote
        bundles.Add(New ScriptBundle("~/Content/summernote/js").Include(
            "~/Content/global/plugins/bootstrap-summernote/summernote.js"))

        'Js Summernote
        bundles.Add(New ScriptBundle("~/Content/datepicker/js").Include(
            "~/Content/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"))

        'Js FlotChart
        bundles.Add(New ScriptBundle("~/Content/flotchart/js").Include(
            "~/Content/global/plugins/flot/jquery.flot.js",
            "~/Content/global/plugins/flot/jquery.flot.resize.js",
            "~/Content/global/plugins/flot/jquery.flot.pie.js",
            "~/Content/global/plugins/flot/jquery.flot.stack.js",
            "~/Content/global/plugins/flot/jquery.flot.crosshair.js",
            "~/Content/global/plugins/flot/jquery.flot.categories.js"))

        'Js Star-Rating
        bundles.Add(New ScriptBundle("~/Content/star-rating/js").Include(
            "~/Content/global/plugins/bootstrap-star-rating/js/star-rating.js"))
    End Sub
End Class