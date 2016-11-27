Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Accueil() As ActionResult
            Return View("Accueil")
        End Function
    End Class
End Namespace