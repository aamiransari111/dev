Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading
Imports System.Web
Imports System.Xml
Imports System.Xml.XPath
Imports Account
Imports Business.Domain
Imports Business.Product
Imports Core1.Common.DAL
Imports Microsoft.VisualBasic
Imports Products
Imports Restaurant_Details
Imports Review

Namespace INCLUDES.Controls
    Public Class IncludesControlsCustomheader
        Inherits System.Web.UI.UserControl
        Public Isschema As Boolean = False, IsParentForCampaign As Boolean = False, _iscorp As Boolean = False

        Dim _addresscolumn As String = "", _citypincolumn As String = "", _statecountrycolumn As String = ""
        Dim _telcolumn As String = "", _websitecolumn As String = "", _landmarkcolumn As String = "", _pincolumn As String = "", _citycolumn As String = ""
        Dim _statecolumn As String = "", _countrycolumn As String = ""
        Public Whatever As String = ""
        ReadOnly _stradress As New StringBuilder
        Public Username, TweetTitle As String, Username1 As String = "", TelePhone As String = "", Cid As Long, Strcatname As String
        Public ObjProduct As Business.Domain.MsData, Reviewset, Custdetail, MenuDetail, Ho, Po, Ad As DataSet
        Protected ArrRatingQuestion As New ArrayList
        Public ParentName As String, StrmsidMixpix As String = "", Catname As String = "", Cty As Int16, Totcount, Rowcount, IntTdNumber, Rowcount1 As Integer

        Dim _pageName As String = ""
        Public IsUsGads As Boolean = CType(ConfigurationManager.AppSettings("isUSGads"), Boolean), IsCorpShow As Boolean = CType(ConfigurationManager.AppSettings("isCorpShow"), Boolean)
        Public ObjGads As New GoogleAds, Region As String = ConfigurationManager.AppSettings("country"), Pagerecords As New PagedDataSource
        Public Recommendationcnt As Integer, Ratingcnt As Double = 5, Isedit As Int16
        Public Editreview As Int16, Mainurl As String
        Public Mainurlis As String, AlertEmail As New DataSet, AlertMob As New DataSet, StralertEmail As String = "", StralertMob As String = ""
        Public SetAlert As String = "", Firstrevby As String, Level1 As Long, Iswritereview As Boolean = True, Readreviewid As Long = 0
        Private _varcorprespcount As Integer = 0, _reviewtitle As String
        Public Mergedprods As String = "", IsmergeNew As Boolean = False, CidOfuserreview As Long, StrReadAlltype As String = "normal", Parentid, Parent21 As Long
        Public Showlisting As Boolean = False, RDate As String
        Dim _loginId As Long
        Public LoginName As String, LoginNameAz As String = "guest", IsDeletedReview As Boolean = False, ExprCnt As Integer = 0, NorRevCnt As Integer = 0
        Public Movielink As String, Orderid As String = "", Emailid As String = "", DsverRevId As DataSet, VerUser As Long = 0, VerRevId As String = ""
        Public InvalVerUser As Boolean = False, verified_reviewid As String = "", EditVerRev As Integer = 0, Isverified As Integer = 0, GenVerRev As Integer = 0
        Public DisableWrtRev As Boolean = False, HideWritRev As Boolean = False, IsBot As String = "0", TypeSpecs As Integer
        Public Mshost As String = ConfigurationManager.AppSettings("ms_host"), Revcount As String = ""
        Public Strcity, Strloc, ProdNameNoloc As String, Contesturl As String, DsImgProdNew As New DataSet, MaxDateforAnalyse As Integer, MindateforAnalyse As Integer
        Public CheckCorp As Boolean = False, IsCustomTable As Boolean = False, Strreviewtitle As String, Iscorpproduct As String = ""
        Dim _jsonLdSnippetProduct As String = "", _strHeaderContent As String, _productName As String, _level1Hierarcy As String
        Public Deleted As Boolean = False, Isadvice As Boolean = False, Parent1 As Integer
        Dim _reviewrating As String, _reviewauthor As String, _twitter As String, _parent2 As Long
        Dim EnableReviewsCache As Boolean = Common.GetXmlValues("/Values/EnableReviewsCache", ConfigurationManager.AppSettings("ImageServerPhysicalPath").ToString() & "Offline\Common\CommonValues.xml", "CommonValues_Cache")
        Dim CachingStatus As Integer
        Dim cachepath As String = ConfigurationManager.AppSettings("ReviewsCachePath").ToString()
        Public Property Settwitter() As String
            Get
                Return _twitter
            End Get
            Set(value As String)
                _twitter = value
            End Set
        End Property

        Public Property Setrecommendation() As Integer
            Get
                Return Recommendationcnt
            End Get
            Set(value As Integer)
                Recommendationcnt = value
            End Set
        End Property
        Public Property SetRatingcnt() As Double
            Get
                Return Ratingcnt
            End Get
            Set(ByVal value As Double)
                Ratingcnt = value
            End Set
        End Property
        Public Property SetreviewRating() As String
            Get
                Return _reviewrating
            End Get
            Set(ByVal value As String)
                _reviewrating = value
            End Set
        End Property
        Public Property Setreviewauthor() As String
            Get
                Return _reviewauthor
            End Get
            Set(ByVal value As String)
                _reviewauthor = value
            End Set
        End Property
        Public Property GetParent2() As Long
            Get
                Return _parent2
            End Get
            Set(ByVal value As Long)
                _parent2 = value
            End Set
        End Property
        Public Property Getparent() As Integer
            Get
                Return Parent1
            End Get
            Set(ByVal value As Integer)
                Parent1 = value
            End Set
        End Property

        Public Property Getlevel1() As Long
            Get
                Return Level1
            End Get
            Set(ByVal value As Long)
                Level1 = value
            End Set
        End Property
        Public Property Getcatname() As String
            Get
                Return Catname
            End Get
            Set(ByVal value As String)
                Catname = value
            End Set
        End Property

        Public Property GetLevel1Hierarcy() As String
            Get
                Return _level1Hierarcy
            End Get
            Set(ByVal value As String)
                _level1Hierarcy = value
            End Set
        End Property
        Public Property Getrevid() As Long
            Get
                Return Readreviewid
            End Get
            Set(ByVal value As Long)
                Readreviewid = value
            End Set
        End Property

        Public Property Getadvice() As Boolean
            Get
                Return Isadvice
            End Get
            Set(ByVal value As Boolean)
                Isadvice = value
            End Set
        End Property

        Public Property Gettitle() As String
            Get
                Return _reviewtitle
            End Get
            Set(ByVal value As String)
                _reviewtitle = value
            End Set
        End Property
        Public Property ProductName() As String
            Get
                Return _productName
            End Get
            Set(ByVal value As String)
                _productName = value
            End Set
        End Property
        Public Property IsCorp() As Boolean
            Get
                Return _iscorp
            End Get
            Set(value As Boolean)
                _iscorp = value
            End Set
        End Property


        Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            Try
                Hierarchy1.CategoryID = Cid
                Hierarchy1.revTitle = _reviewtitle
                Strcatname = Catname
                CachingStatus = DAL.ExecuteScalar("declare @status numeric if exists (select 1 from ms_Caching_Track (nolock) where cat_id=" & Cid & ") set @status = (select status1 from ms_Caching_Track (nolock) where cat_id=" & Cid & ") else set @status = 0 select @status")

                If Not File.Exists(ConfigurationManager.AppSettings("ImageServerPhysicalPath") & cachepath & "\customheader\" & ObjProduct.CatId & ".txt") Then
                    CachingStatus = 0
                End If
                BindStarRating()
                BindSpecification()
                Getdata()
            Catch ex As Exception
                Logger.WriteError("Error in property photos Repeater")
            End Try
        End Sub
        Private Sub Getdata()
            Dim edit = Request.QueryString("edit")

            Movielink = Common.getmovielink(_parent2, Level1)
            Call getshareoption()
            Call getcategoryname()
            If Not _reviewtitle Is Nothing AndAlso _reviewtitle.EndsWith(".") = False Then
                _reviewtitle = _reviewtitle & "."
            End If
            Strreviewtitle = _reviewtitle
            'Iscorpproduct = CType(DAL.ExecuteScalar("select user_name from ms_user, ms_corp_products m2 where m2.corpid = user_id and m2.cat_id =" & Cid), String)
            If Session("iscorporate") Then
                Iscorpproduct = Session("iscorporate")
                If Request.Url.PathAndQuery.ToLower.Contains("readreview.php") Then
                    spnverified1.Visible = True
                Else
                    spnverified.Visible = True
                End If


            End If



            Cty = 1
            Page.RegisterStartupScript("LinkButton123", "<script>if(document.getElementById('LinkButton1')!=null) document.getElementById('LinkButton1').style.display = '';</script>")
            If CBlog.Corporate.chkSubUser(CLng(Session("id"))) = True Then
                LoginName = CType(CBlog.Corporate.getsubuser_corp(CLng(Session("id"))), String)
                LoginNameAz = CType(CBlog.Corporate.getsubuser_corp(CLng(Session("id"))), String)
                _loginId = Account.UserFacade.GetUsrNumIdByName(LoginName)
            Else
                _loginId = CType(Session("id"), Long)
                LoginName = CType(Session("name"), String)
                LoginNameAz = CType(Session("name"), String)
            End If
            Contesturl = Mshost & "contest"
            If Request.QueryString("ratereview") = "1" And Session("id") <> 0 Then
                Page.RegisterStartupScript("writeexpressreview", "<script>redirecttowrite();</script>")
            End If
            If edit <> "" And (Session("edited") Is Nothing OrElse Session("edited") = 0) Then
                Isedit = CType(edit, Short)
            Else
                Session("edited") = 0
            End If

            Mshost = ConfigurationManager.AppSettings("ms_host").ToString
            'SessionId = CLng(Session("id"))
            Username = CType(Session("name"), String)
            Parent21 = ObjProduct.Parent2
            Parentid = ObjProduct.Parent
            Catname = ObjProduct.CatName.ToString.Replace("'", "")
            Movielink = Common.getmovielink(ObjProduct.Parent2, ObjProduct.Level1)
            Strcatname = ObjProduct.CatName

            If Not IsPostBack Then
                If Session("id") > 0 Then
                    Dim dr As SqlClient.SqlDataReader
                    dr = DAL.ExecuteDataReader("select email, name + ' ' + isnull(namelast,'') as 'name',mp.telephone from ms_personal mp, ms_user mu where mu.user_id=mp.user_id and mu.user_id =" & _loginId)
                    While dr.Read
                        Username1 = dr("name").ToString().Trim
                        StralertEmail = dr("email").ToString()
                        TelePhone = dr("telePhone").ToString()

                        txtName.Text = Username1
                        txtMob.Text = TelePhone
                        txtMail.Text = StralertEmail
                    End While
                    dr = Nothing
                End If
            End If

            txtModel.Value = Catname

            Dim str As String = ""
            If Mergedprods <> "" Then
                'iscorprev = DAL.ExecuteScalar("Select mr.user_id from ms_review" & Common.SuffixDomain & " mr, ms_user mu where mr.cat_id in (" & mergedprods & ") and  mr.user_id = mu.user_id and mu.iscorporate=1 and mu.user_id in (select corpid from ms_corp_products where cat_id =" & ObjProduct.CatId & ")")
                If Not Request.QueryString("ver_key") Is Nothing Then
                    Orderid = Request.QueryString("ver_key")
                End If
                Dim userrev As DataSet
                If Orderid = "" Then
                    userrev = DAL.ExecuteDataset(CType(("SELECT review_id, cat_id,isexpressreview from ms_review where cat_id in (" & Mergedprods & ") and user_id='" & Session("id") & "' order by ms_date desc"), String))
                Else
                    userrev = DAL.ExecuteDataset("select mvr.review_key,mr.isexpressreview,mvr.verified_key,mr.cat_id,mr.user_id,mscorp.corpid,mr.review_id from ms_verified_review mvr,ms_review mr,ms_corp_products mscorp  where mvr.review_key=mr.review_key and mscorp.cat_id=mr.cat_id and mvr.verified_key='" & Orderid & "' and mr.cat_id in (" & Mergedprods & ")")
                End If
                If Not IsDBNull(userrev) AndAlso userrev.Tables(0).Rows.Count > 0 Then
                    Dim urdt As DataRow() = userrev.Tables(0).Select("cat_id=" & Cid)
                    If urdt.Length > 0 Then
                        str = CType(urdt(0)("review_id"), String)
                        CidOfuserreview = CType(urdt(0)("cat_id"), Long)
                    Else
                        str = CType(userrev.Tables(0).Rows(0)("review_id"), String)
                        CidOfuserreview = CType(userrev.Tables(0).Rows(0)("cat_id"), Long)
                    End If

                Else
                    str = ""
                    CidOfuserreview = ObjProduct.CatId
                End If
            Else

                'iscorprev = DAL.ExecuteScalar("Select mr.user_id from ms_review" & Common.SuffixDomain & " mr, ms_user mu where mr.cat_id=" & ObjProduct.CatId & " and  mr.user_id = mu.user_id and mu.iscorporate=1 and mu.user_id in (select corpid from ms_corp_products where cat_id =" & ObjProduct.CatId & ")")
                If Session("id") > 0 Then
                    str = AdminCommon.dbCommon.ExecuteSQL(("SELECT review_id from ms_review where cat_id='" & Cid & "' and user_id='" & CType(Session("id"), String) & "'"), 1, "4")
                End If
                CidOfuserreview = ObjProduct.CatId
            End If
            If ReadWrite.IsVerified(Cid) Then
                Isverified = 1
                If Common.SuffixDomain.ToLower <> "_us" Then
                    If Not Request.QueryString("ver_key") Is Nothing AndAlso Request.QueryString("ver_key") <> "" Then
                        VerRevId = verified_reviewid
                        Orderid = Request.QueryString("ver_key")
                    ElseIf EditVerRev = 1 Then
                        EditVerRev = 1
                    ElseIf GenVerRev = 1 Then
                        GenVerRev = 1
                    Else
                        DisableWrtRev = True
                        Orderid = ""
                        Emailid = ""
                    End If
                End If
            End If
            If Readreviewid <> 0 Then
                CidOfuserreview = ObjProduct.CatId
            End If
            'iscorpproduct = DAL.ExecuteScalar("select user_name from ms_user, ms_corp_products m2 where m2.corpid = user_id and m2.cat_id =" & ObjProduct.CatId)
            If Session("corporateName") <> "" Then
                lblwritereview.InnerText = "Write Your Review"
                btnwritereview.Attributes.Add("title", "Write Your Review")
                btnwritereview.Attributes.Add("onclick", "submit_corporate(); return false;")
            Else
                If Isverified = "1" And Session("id") = 0 Then
                    lblwritereview.InnerText = "Write Your Review"
                    btnwritereview.Attributes.Add("title", "Write Your Review")
                    If Request.Url.AbsoluteUri.ToLower.IndexOf("lyrics.aspx", StringComparison.Ordinal) > -1 OrElse Request.Url.AbsoluteUri.ToLower.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) > -1 Then
                        btnwritereview.Attributes.Add("onclick", "javascript:ajaxLogin('" & ConfigurationManager.AppSettings("parent_host").ToString & "review/write_review.php?cid=" & Cid & ");")
                    Else
                        If DisableWrtRev = True And ObjProduct.OldCatName = "1" Then
                            btnwritereview.Attributes.Add("onclick", "javascript:ajaxLogin('');")
                        Else
                            btnwritereview.Attributes.Add("onclick", "javascript:ajaxLogin('" & Request.ServerVariables("HTTP_X_REWRITE_URL").ToString & "#writerev');")
                        End If
                    End If
                ElseIf Isverified = "1" And Session("id") > 0 Then
                    If str <> "" Then
                        Editreview = 1
                        lblwritereview.InnerText = "Edit Your Review"
                        btnwritereview.Attributes.Add("title", "Edit Your Review")
                        If Request.Url.AbsoluteUri.ToLower.IndexOf("lyrics.aspx", StringComparison.Ordinal) > -1 OrElse Request.Url.AbsoluteUri.ToLower.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) > -1 Then
                            btnwritereview.Attributes.Add("onclick", "window.location.href='" & ConfigurationManager.AppSettings("parent_host").ToString & "review/write_review.php?cid=" & Cid & "'")
                        Else
                            btnwritereview.Attributes.Add("onclick", "WriteReview(); return false;")
                        End If
                    Else
                        If DisableWrtRev = True And ObjProduct.OldCatName = "1" Then
                            lblwritereview.InnerText = "Write Your Review"
                            btnwritereview.Attributes.Add("title", "Write Your Review")
                            If ObjProduct.CatId = 925715825 Then
                                btnwritereview.Attributes.Add("onclick", "alert('This brand indulges in FAKE reviews, hence review writing has been temporarily disabled.'); return false;")
                            Else
                                btnwritereview.Attributes.Add("onclick", "submit_review_verified(); return false;")
                            End If
                        Else
                            lblwritereview.InnerText = "Write Your Review"
                            btnwritereview.Attributes.Add("title", "Write Your Review")
                            If Request.Url.AbsoluteUri.ToLower.IndexOf("lyrics.aspx", StringComparison.Ordinal) > -1 OrElse Request.Url.AbsoluteUri.ToLower.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) > -1 Then
                                btnwritereview.Attributes.Add("onclick", "window.location.href='" & ConfigurationManager.AppSettings("parent_host").ToString & "review/write_review.php?cid=" & Cid & "'")
                            Else
                                btnwritereview.Attributes.Add("onclick", "WriteReview(); return false;")
                            End If
                        End If

                    End If
                Else
                    If str <> "" Then
                        Editreview = 1
                        lblwritereview.InnerText = "Edit Your Review"
                        btnwritereview.Attributes.Add("title", "Edit Your Review")
                        If Request.Url.AbsoluteUri.ToLower.IndexOf("lyrics.aspx", StringComparison.Ordinal) > -1 OrElse Request.Url.AbsoluteUri.ToLower.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) > -1 Then
                            btnwritereview.Attributes.Add("onclick", "window.location.href='" & ConfigurationManager.AppSettings("parent_host").ToString & "review/write_review.php?cid=" & Cid & "'")
                        Else
                            If Session("id") > 0 Then
                                btnwritereview.Attributes.Add("onclick", "WriteReview(); return false;")
                            Else
                                btnwritereview.Attributes.Add("onclick", CType(("javascript:ajaxLogin('" & Session("reviewurlredirect") & "');"), String))
                            End If
                        End If
                    Else
                        lblwritereview.InnerText = "Write Your Review"
                        btnwritereview.Attributes.Add("title", "Write Your Review")
                        If Request.Url.AbsoluteUri.ToLower.IndexOf("lyrics.aspx", StringComparison.Ordinal) > -1 OrElse Request.Url.AbsoluteUri.ToLower.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) > -1 Then
                            btnwritereview.Attributes.Add("onclick", "window.location.href='" & ConfigurationManager.AppSettings("parent_host").ToString & "review/write_review.php?cid=" & Cid & "'")
                        Else
                            If Session("id") > 0 And ObjProduct.OldCatName = "1" Then
                                btnwritereview.Attributes.Add("onclick", "writereview_disabled(); return false;")
                            ElseIf Session("id") > 0 Then
                                btnwritereview.Attributes.Add("onclick", "WriteReview(); return false;")
                            Else
                                If ObjProduct.OldCatName = "1" Then
                                    btnwritereview.Attributes.Add("onclick", "javascript:ajaxLogin('');")
                                Else
                                    btnwritereview.Attributes.Add("onclick", "javascript:ajaxLogin('" & Request.ServerVariables("HTTP_X_REWRITE_URL").ToString & "#writerev');")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            'masterId = ObjProduct.Parent
            If ObjProduct.Advice = True Then
                If str <> "" Then
                    lblwritereview.InnerText = "Edit Your Tip"
                    btnwritereview.Attributes.Add("title", "Edit Your Tip")
                Else
                    lblwritereview.InnerText = "Write Your Tip"
                    btnwritereview.Attributes.Add("title", "Write Your Tip")
                End If
                btnwritereview.Attributes.Add("class", "btn btn-secondary write-review")
                dvCusHead.Attributes.Add("style", "display:none;")
                prodImg.Attributes.Add("style", "display:none;")
            End If
            litonlyrevcnt.Text = "0"
            NorRevCnt = 0

            If Mergedprods <> "" And IsmergeNew = True Then
                Dim dt As DataTable = DAL.ExecuteDataset("select isexpressreview,count(review_id)  as 'cnt' from ms_review" & Common.SuffixDomain & " where     (show=1 or show is null or show =2) and cat_id = " & Cid & " and (isverified=1 or isverified is null) group by isexpressreview order by isexpressreview asc").Tables(0)
                If Not dt Is Nothing And dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If CType(dt.Rows(i).Item("isexpressreview"), Boolean) = True Then
                            ExprCnt = CType(dt.Rows(i)("cnt"), Integer)
                            litonlyrevcnt.Text = CType((litonlyrevcnt.Text + dt.Rows(i)("cnt")), String)
                        Else
                            litonlyrevcnt.Text = CType(dt.Rows(i)("cnt"), String)

                        End If
                    Next
                End If
            ElseIf Mergedprods <> "" And IsmergeNew <> True Then
                Dim dt As DataTable = DAL.ExecuteDataset("select isexpressreview,count(review_id)  as 'cnt' from ms_review" & Common.SuffixDomain & " where  (show=1 or show is null or show =2) and cat_id in (" & Mergedprods & ") and (isverified=1 or isverified is null) group by isexpressreview order by isexpressreview asc").Tables(0)
                If Not dt Is Nothing And dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If CType(dt.Rows(i).Item("isexpressreview"), Boolean) = True Then
                            litonlyrevcnt.Text = CType((litonlyrevcnt.Text + dt.Rows(i)("cnt")), String)
                        Else
                            litonlyrevcnt.Text = CType(dt.Rows(i)("cnt"), String)
                        End If
                    Next
                End If
            Else
                Dim dt As DataTable = DAL.ExecuteDataset("select isexpressreview,count(review_id)  as 'cnt' from ms_review" & Common.SuffixDomain & " where  (show=1 or isnull(show,2) =2) and cat_id = " & Cid & " and (isnull(isverified,1)=1) group by isexpressreview").Tables(0)
                If Not dt Is Nothing And dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If CType(dt.Rows(i).Item("isexpressreview"), Boolean) = True Then
                            'exprcount.Text = dt.Rows(i)("cnt")
                            ExprCnt = CType(dt.Rows(i)("cnt"), Integer)
                            litonlyrevcnt.Text = CType((litonlyrevcnt.Text + dt.Rows(i)("cnt")), String)
                            adviceCount.Text = CType((litonlyrevcnt.Text + dt.Rows(i)("cnt")), String)
                        Else
                            litonlyrevcnt.Text = CType(dt.Rows(i)("cnt"), String)
                            adviceCount.Text = CType(dt.Rows(i)("cnt"), String)
                        End If
                    Next
                End If
            End If
            NorRevCnt = CType(litonlyrevcnt.Text, Integer)
            'productsummary.revCount = norRevCnt
            If litonlyrevcnt.Text = "1" Then
                litonlyrevcnt.Text = "1 Review"
            ElseIf litonlyrevcnt.Text = "0" Then
                litonlyrevcnt.Text = "0 Reviews"
            Else
                litonlyrevcnt.Text &= " Reviews"
            End If
            Catname = ObjProduct.CatName.ToString.Replace("'", "")
            Session("level1") = ObjProduct.Level1
            Level1 = ObjProduct.Level1

            If Mergedprods <> "" Then
                If IsmergeNew = True Then
                    Ratingcnt = ObjProduct.Rating
                Else
                    ReadReviewHelper.getmergedrating(Mergedprods, Ratingcnt, Recommendationcnt)
                End If
            Else
                Ratingcnt = ObjProduct.Rating
            End If

            'Try
            '    Dim objCommonBo As New CommonBO
            '    If Not Session("CommonBO") Is Nothing Then
            '        objCommonBo = TryCast(Session("CommonBO"), CommonBO)
            '        Dim rating As String
            '        Try
            '            Dim ratingvalue As Decimal
            '            ratingvalue = Convert.ToDecimal(ObjProduct.Rating)
            '            rating = ratingvalue.ToString("#.##")
            '        Catch ex As Exception
            '            rating = ObjProduct.Rating.ToString()
            '        End Try
            '        If (rating = "") Then
            '            rating = "0"
            '        End If
            '        If ObjProduct.Advice = False Then
            '            rating = " (Rating-" + Ratingcnt.ToString() & "/5)"
            '        Else
            '            rating = ""
            '        End If

            '        objCommonBo.FbMessage = "Thought I would share " + (ObjProduct.CatName).Replace("'", "") + rating
            '        objCommonBo.TwitterMessage = "Thought I would share " + (ObjProduct.CatName).Replace("'", "") + rating + " #WriteShareWin"
            '        Session("CommonBO") = objCommonBo
            '    End If
            'Catch ex As Exception

            'End Try

            processData()

            If Mergedprods <> "" Then
                If IsmergeNew = True Then
                    Recommendationcnt = ObjProduct.Recommendation
                    lblRecommendation.Text = ObjProduct.Recommendation & "%"
                Else
                End If
                lblRecommendation.Text = Recommendationcnt & "%"
            Else
                Recommendationcnt = ObjProduct.Recommendation
                lblRecommendation.Text = ObjProduct.Recommendation & "%"
            End If

            If ObjProduct.Advice = False Then
                lblProductRating.Text = Product.ProdRatingSprites(Ratingcnt)

            Else
                Ratingcnt = 5
                dvRecBy.Visible = False
            End If
            displayaddressandphone()
            If StrReadAlltype = "restaurant" Then
                Custdetail = DAL.ExecuteDataset("select * from restaurants" & Common.SuffixDomain & " where catid=" & Cid)
                If Custdetail.Tables(0).Rows.Count > 0 Then
                    Dim custid As String = Custdetail.Tables(0).Rows(0).Item("custid").ToString
                    Catname = Catname.Replace("'", "''")
                    lt.Value = Convert.ToString(Custdetail.Tables(0).Rows(0)("latitude"))
                    lngd.Value = Convert.ToString(Custdetail.Tables(0).Rows(0)("longitude"))
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("address")) AndAlso Custdetail.Tables(0).Rows(0).Item("address") <> "" AndAlso Not IsCustomTable Then
                        Dim data As String = Custdetail.Tables(0).Rows(0).Item("Address").ToString
                        data = Regex.Replace(data, "(((upper )|(lower ))*(ground floor)+(,)*)", "", RegexOptions.IgnoreCase)
                        data = Regex.Replace(data, "Time:.*<br>", "", RegexOptions.IgnoreCase)
                        data = Regex.Replace(data, "Cuisine:.*", "", RegexOptions.IgnoreCase)
                        data = data.Replace("<br>", "~")
                        data = data.Replace("<BR>", "~")
                        data = data.Replace("''", "'")
                        Dim testadrarr() As String = data.Split(CType("~", Char))
                        Dim testadrlen As Integer = testadrarr.Length

                        Dim cnt, telfoundat, scfoundat, citypinfoundat As Integer
                        For cnt = testadrarr.Length - 1 To 0 Step -1
                            If telfoundat = cnt + 1 And _telcolumn <> "" Then
                                _statecountrycolumn = testadrarr(cnt)
                                Dim statecountryarr1() As String = _statecountrycolumn.Split(CType(",", Char))
                                _statecolumn = statecountryarr1(0)
                                Try
                                    _countrycolumn = statecountryarr1(1)
                                Catch ex As Exception

                                End Try
                                scfoundat = cnt
                            End If
                            If scfoundat = cnt + 1 And _statecolumn <> "" Then
                                _citypincolumn = testadrarr(cnt)
                                Dim citypinarr1() As String = _citypincolumn.Split(CType(" ", Char))
                                If citypinarr1.Length > 1 Then
                                    Dim s1 As String = citypinarr1(citypinarr1.Length - 1)
                                    If IsNumeric(s1) Then
                                        Dim i As Integer
                                        For i = 0 To citypinarr1.Length - 2
                                            _citycolumn = _citycolumn & citypinarr1(i)
                                        Next
                                        _pincolumn = s1
                                    Else
                                        _citycolumn = _citypincolumn
                                    End If
                                Else
                                    If IsNumeric(_citypincolumn) Then
                                        _pincolumn = _citypincolumn
                                    Else
                                        _citycolumn = _citypincolumn
                                    End If
                                End If
                                citypinfoundat = cnt
                            End If
                            If citypinfoundat = cnt + 1 And _citycolumn <> "" Then
                                _addresscolumn = testadrarr(cnt) & _addresscolumn
                            ElseIf citypinfoundat = cnt + 1 And _citycolumn = "" Then
                                _addresscolumn = testadrarr(cnt) & _addresscolumn
                            End If

                            If testadrarr(cnt).ToString.IndexOf("Tel:", StringComparison.Ordinal) > -1 AndAlso testadrarr(cnt) <> "" Then
                                _telcolumn = testadrarr(cnt).ToString & _telcolumn
                                telfoundat = cnt
                            End If
                            If testadrarr(cnt).ToString.IndexOf("+91", StringComparison.Ordinal) > -1 AndAlso telfoundat = 0 AndAlso testadrarr(cnt) <> "" Then
                                _telcolumn = _telcolumn & "|" & testadrarr(cnt).ToString.ToLower
                            End If

                            If testadrarr(cnt).ToString.IndexOf("<a", StringComparison.Ordinal) > -1 AndAlso testadrarr(cnt).ToString.IndexOf("</a>", StringComparison.Ordinal) > -1 Then
                                _websitecolumn = testadrarr(cnt).ToString & _telcolumn
                                _websitecolumn = _websitecolumn.Substring(0, _websitecolumn.IndexOf(">", StringComparison.Ordinal)) & " rel='nofollow' " & _websitecolumn.Substring(_websitecolumn.IndexOf(">", StringComparison.Ordinal))
                            End If

                            If testadrarr(cnt).ToString.IndexOf("Landmark:", StringComparison.Ordinal) > -1 Then
                                _landmarkcolumn = testadrarr(cnt).ToString
                            End If
                        Next
                        If _addresscolumn = "" Then
                            dvAddress.Visible = True
                            If data.ToLower.Contains("href") AndAlso Not data.ToLower.Contains("nofollow") Then
                                _addresscolumn = (data.Substring(0, data.IndexOf(">", StringComparison.Ordinal)) & " rel='nofollow' " & data.Substring(data.IndexOf(">", StringComparison.Ordinal))).Replace("~", "<br/>")
                            Else
                                _addresscolumn = data.Replace("~", "<br/>")
                            End If
                            Dim addr() As String = Regex.Split(_addresscolumn, "Tel:")
                            litcustaddr.Text = addr(0)
                            If addr.Length - 1 > 0 Then
                                If addr(1).ToLower.IndexOf("website", StringComparison.Ordinal) > 0 Then
                                    Dim addremail() As String = Regex.Split(addr(1).ToString.ToLower, "website")
                                    If addremail(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                        Dim addrweb() As String = Regex.Split(addremail(1).ToString.ToLower, "email")
                                        addrweb(0) = addrweb(0).Replace("<br/>", "")
                                        addrweb(0) = addrweb(0).Replace("http://", "")
                                        addrweb(0) = addrweb(0).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    Else
                                        addremail(1) = addremail(1).Replace("<br/>", "")
                                        addremail(1) = addremail(1).Replace("http://", "")
                                        addremail(1) = addremail(1).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    End If
                                    litcusttel.Text = addremail(0).Replace("<br/>", "")
                                    dvtel.Visible = True
                                ElseIf addr(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                    Dim addrweb() As String = Regex.Split(addr(1).ToString.ToLower, "email")
                                    litcusttel.Text = addrweb(0)
                                    dvtel.Visible = True
                                Else
                                    litcusttel.Text = addr(1)
                                    dvtel.Visible = True
                                End If
                            Else
                                Dim telabsent() As String = Regex.Split(_addresscolumn, "Website")
                                Dim webabsent() As String = Regex.Split(_addresscolumn, "Email")
                                If telabsent.Length - 1 > 0 Then
                                    Dim addremail() As String = Regex.Split(addr(0), "Website")
                                    litcustaddr.Text = addremail(0)
                                    If addremail(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                        Dim addrweb() As String = Regex.Split(addremail(1).ToString.ToLower, "email")
                                        addrweb(0) = addrweb(0).Replace("<br/>", "")
                                        addrweb(0) = addrweb(0).Replace("http://", "")
                                        addrweb(0) = addrweb(0).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    End If
                                ElseIf webabsent.Length - 1 > 0 Then
                                    Dim addrweb() As String = Regex.Split(addr(0), "Email")
                                    litcustaddr.Text = addrweb(0)
                                End If
                            End If
                        Else
                            dvAddress.Visible = True
                            litcustaddr.Text = CType(("<span class=""address"">" & IIf(_addresscolumn <> "", _addresscolumn & "<br>", "") & _citycolumn & IIf(_pincolumn <> "", " - " & _pincolumn & "<br>", "<br>") & _statecolumn & " , " & _countrycolumn & "<br>" & IIf(_websitecolumn <> "", _websitecolumn & "<br>", "") & IIf(_landmarkcolumn <> "", _landmarkcolumn & "<br>", "") & "</span>"), String)
                            litcusttel.Text = "<span>" & _telcolumn & "</span>"
                            dvtel.Visible = True
                            _stradress.Append(Replace(litcustaddr.Text & "<br>", "<br>", ",<br>"))
                            litcustaddr.Text = litcustaddr.Text.Replace("Tel:", "<span class=""i-telephone1""></span>: ")
                        End If
                        If Custdetail.Tables(0).Rows(0).Item("Custom_Type") = "8" Then
                            If Custdetail.Tables(0).Rows(0).Item("Details") <> "" AndAlso Not Custdetail.Tables(0).Rows(0).Item("Details") Is Nothing Then
                                dvclass.Visible = True
                                lithotelclass.Text = Custdetail.Tables(0).Rows(0).Item("Details").ToString
                            End If
                        End If
                    Else
                        If (Not ObjProduct.Description Is Nothing AndAlso ObjProduct.Description <> "" AndAlso Not IsCustomTable) Then
                            dvAddress.Visible = True
                            Dim addr() As String = Regex.Split(ObjProduct.Description.ToString, "Tel:")
                            litcustaddr.Text = addr(0)
                            If addr.Length - 1 > 0 Then
                                If addr(1).ToLower.IndexOf("website", StringComparison.Ordinal) > 0 Then
                                    Dim addremail() As String = Regex.Split(addr(1).ToString.ToLower, "website")
                                    If addremail(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                        Dim addrweb() As String = Regex.Split(addremail(1).ToString.ToLower, "email")
                                        addrweb(0) = addrweb(0).Replace("<br/>", "")
                                        addrweb(0) = addrweb(0).Replace("http://", "")
                                        addrweb(0) = addrweb(0).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    Else
                                        addremail(1) = addremail(1).Replace("<br/>", "")
                                        addremail(1) = addremail(1).Replace("http://", "")
                                        addremail(1) = addremail(1).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    End If
                                    litcusttel.Text = addremail(0)
                                    dvtel.Visible = True
                                ElseIf addr(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                    Dim addrweb() As String = Regex.Split(addr(1).ToString.ToLower, "email")
                                    litcusttel.Text = addrweb(0)
                                    dvtel.Visible = True
                                Else
                                    litcusttel.Text = addr(1)
                                    dvtel.Visible = True
                                End If
                            Else
                                Dim telabsent() As String = Regex.Split(ObjProduct.Description.ToString, "website")
                                Dim webabsent() As String = Regex.Split(ObjProduct.Description.ToString, "email")
                                If telabsent.Length - 1 > 0 Then
                                    Dim addremail() As String = Regex.Split(addr(0).ToString.ToLower, "website")
                                    litcustaddr.Text = addremail(0)
                                    If addremail(1).ToLower.IndexOf("email", StringComparison.Ordinal) > 0 Then
                                        Dim addrweb() As String = Regex.Split(addremail(1).ToString.ToLower, "email")
                                        addrweb(0) = addrweb(0).Replace("<br/>", "")
                                        addrweb(0) = addrweb(0).Replace("http://", "")
                                        addrweb(0) = addrweb(0).ToLower.Replace("website", "").Trim.Remove(0, 1)
                                    End If
                                ElseIf webabsent.Length - 1 > 0 Then
                                    Dim addrweb() As String = Regex.Split(addr(0).ToString.ToLower, "email")
                                    litcustaddr.Text = addrweb(0)
                                End If
                            End If
                        End If
                    End If

                    If litcustaddr.Text.IndexOf("<br>", StringComparison.Ordinal) = 0 Then
                        litcustaddr.Text = litcustaddr.Text.Remove(0, 4)
                    End If

                    

                    If ObjProduct.Parent = "7" Then
                        If Custdetail.Tables(0).Rows(0).Item("Custom_Type") = "3" And Custdetail.Tables(0).Rows(0).Item("HighLight") <> "" Then
                            LitBrandname.Text = Custdetail.Tables(0).Rows(0).Item("HighLight").ToString()
                            dvbrand.Visible = True
                            dvAddress.Visible = True
                        End If
                    End If
                    If lt.Value <> "0" And lt.Value <> "" And (ObjProduct.Parent2 = 925062123 Or ObjProduct.Parent2 = 925040057) Then 'And (Product.GetProductImageSource_ObjProduct(ObjProduct, "o") <> "") Then
                        imgproduct.ImageUrl = Mshost & "images/map.jpg"

                    Else
                        If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("logoImg")) AndAlso Custdetail.Tables(0).Rows(0).Item("logoImg") <> "" AndAlso Custdetail.Tables(0).Rows(0).Item("logoImg") <> "0" Then
                            imgproduct.ImageUrl = CType((ConfigurationManager.AppSettings("ImageServerVirtualPath") & "Restaurant/Logo_Owner/" & Custdetail.Tables(0).Rows(0).Item("ImgName") & "-" & Custdetail.Tables(0).Rows(0).Item("catid") & Custdetail.Tables(0).Rows(0).Item("logoImg")), String)
                        Else
                            If ObjProduct.Parent2 = "925062123" Or ObjProduct.Parent2 = "925040057" Then
                                If Product.GetProductImageSource_objproduct(ObjProduct, "o").Contains("comingsoon") Then
                                    imgproduct.Attributes.Add("src", Product.GetProductImageSource_objproduct(ObjProduct, "o"))
                                Else
                                    imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "o")
                                End If
                            Else
                                imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "o")
                            End If
                        End If
                        imgproduct.ToolTip = ObjProduct.CatName & " photo"
                        imgproduct.Attributes.Add("alt", ObjProduct.CatName & " Image")
                    End If
                Else
                    imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "o")
                End If
            ElseIf StrReadAlltype = "movie" Then
                Custdetail = DAL.ExecuteDataset("select * from movie_music" & Common.SuffixDomain & " where catid=" & Cid)
                If Custdetail.Tables(0).Rows.Count > 0 Then
                    Dim cnt As Int16 = 0
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("Rdate")) Then
                        SpnRelease.Attributes.Add("style", "display:block;")
                        Dim str1 As Date = CType(Custdetail.Tables(0).Rows(0).Item("Rdate"), Date)
                        RDate = str1.ToString("MMMM dd, yyyy")
                        litRelease.Text = str1.ToString("MMMM dd, yyyy")
                        dvH.Visible = True
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("cast")) AndAlso Custdetail.Tables(0).Rows(0).Item("cast") <> "" Then
                        SpnStar.Attributes.Add("style", "display:block;")
                        litStar.Text = CType((Custdetail.Tables(0).Rows(0).Item("cast").replace("&quot;", "'") & "<br />"), String)
                        dvH.Visible = True
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("director")) AndAlso Custdetail.Tables(0).Rows(0).Item("director") <> "" Then
                        SpnDirector.Attributes.Add("style", "display:block;")
                        litDirector.Text = CType((Custdetail.Tables(0).Rows(0).Item("director").replace("&quot;", "'") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("musicdirector")) AndAlso Custdetail.Tables(0).Rows(0).Item("musicdirector") <> "" Then
                        SpnMusic.Attributes.Add("style", "display:block;")
                        litMusic.Text = CType((Custdetail.Tables(0).Rows(0).Item("musicdirector").replace("&quot;", "'") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("producer")) AndAlso Custdetail.Tables(0).Rows(0).Item("producer") <> "" Then
                        SpnProducer.Attributes.Add("style", "display:block;")
                        litProducer.Text = CType((Custdetail.Tables(0).Rows(0).Item("producer").replace("&quot;", "'") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("genre")) AndAlso Custdetail.Tables(0).Rows(0).Item("genre") <> "" Then
                        SpnGenre.Attributes.Add("style", "display:block;")
                        litGenre.Text = CType((Custdetail.Tables(0).Rows(0).Item("genre") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("Details")) AndAlso Custdetail.Tables(0).Rows(0).Item("Details") <> "" Then
                        SpnExtra.Attributes.Add("style", "display:block;")
                        litExtra.Text = CType((Custdetail.Tables(0).Rows(0).Item("Details") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("highlight")) AndAlso Custdetail.Tables(0).Rows(0).Item("highlight") <> "" Then
                        SpnStoryline.Attributes.Add("style", "display:block;")
                        litStoryline.Text = CType((Custdetail.Tables(0).Rows(0).Item("highlight") & "<br />"), String)
                    End If
                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("Description")) AndAlso Custdetail.Tables(0).Rows(0).Item("Description") <> "" Then
                        SpnDescription.Attributes.Add("style", "display:block;")
                        litDescription.Text = CType((Custdetail.Tables(0).Rows(0).Item("Description") & "<br />"), String)
                    End If

                    If Not IsDBNull(Custdetail.Tables(0).Rows(0).Item("Webpage")) AndAlso Custdetail.Tables(0).Rows(0).Item("Webpage") <> "" Then
                        SpnWebpage.Attributes.Add("style", "display:block;")
                        litWebpage.Text = CType(("<a href='http://" & Custdetail.Tables(0).Rows(0).Item("Webpage") & "'  target='_blank' class='url'>" & Custdetail.Tables(0).Rows(0).Item("Webpage") & "</a>" & "<br />"), String)
                    End If
                End If
                imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "l")
                imgproduct.ToolTip = ObjProduct.CatName & " photo"
                imgproduct.Attributes.Add("alt", ObjProduct.CatName & " Image")
            ElseIf StrReadAlltype = "normal" And ObjProduct.Level1 = 925153 Then  'add customer care number
                Dim cuscarenumber As String = Product.GetOnlineShoppingCustCare(ObjProduct.CatId)
                If cuscarenumber <> "" Then
                    dvAddress.Visible = True
                    dvtel.Attributes.Add("onmouseout", "headout(event,3);")
                    dvtel.Attributes.Add("onmouseover", "headover(3);")
                    dvtel.Attributes.Add("title", "Customer Care")
                    litcustaddr.Text = "<span class=""address"">" & "</span>"
                    litcusttel.Text = "<span>" & cuscarenumber & "</span>"
                    dvtel.Visible = True
                    litcustaddr.Text = litcustaddr.Text.Replace("Tel:", "<span class=""i-telephone1""></span>: ")
                End If
                imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "l")
                imgproduct.ToolTip = ObjProduct.CatName & " photo"
                imgproduct.Attributes.Add("alt", ObjProduct.CatName)
            Else
                imgproduct.ImageUrl = Product.GetProductImageSource_objproduct(ObjProduct, "l")
                imgproduct.ToolTip = ObjProduct.CatName & " photo"
                imgproduct.Attributes.Add("alt", ObjProduct.CatName & " Image")
            End If
            If imgproduct.ImageUrl = "" Then
                imgproduct.Attributes.Remove("onclick")
            Else
                imgproduct.Attributes.Add("onclick", "$('.img-responsive:eq(0)').trigger('click');")
            End If

            Dim del As DataSet = DAL.ExecuteDataset("select iscustom from ms_data where cat_id=" & ObjProduct.CatId)
            If Not del Is Nothing AndAlso del.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(del.Tables(0).Rows(0)("iscustom")) Then
                    dvDelStamp.Visible = True
                    If del.Tables(0).Rows(0)("iscustom") = True Then
                        imgClosedDiscontinued.Visible = True
                        imgClosedDiscontinued.ImageUrl = ConfigurationManager.AppSettings("ImageServerVirtualPath").ToString() & "imagesp/closed.png"
                        imgClosedDiscontinued.ToolTip = "The establishment appears to be closed temporarily or permanently"
                    Else
                        imgClosedDiscontinued.Visible = True
                        imgClosedDiscontinued.ImageUrl = ConfigurationManager.AppSettings("ImageServerVirtualPath").ToString() & "imagesp/discontinued.png"
                        imgClosedDiscontinued.ToolTip = "The establishment appears to be closed temporarily or permanently"
                    End If
                End If
            End If
            If ObjProduct.Parent = 7 Or ObjProduct.Parent = 19 Or (ObjProduct.Parent = 18 And ObjProduct.Level1 <> 925153) Or (ObjProduct.Parent = 8 And ObjProduct.Parent2 <> 925069787) Or ObjProduct.Parent2 = 925593078 Or ObjProduct.Parent2 = 925062123 Or ObjProduct.Parent2 = 925040057 Or ObjProduct.Parent2 = 925087251 Or ObjProduct.Parent2 = 925087190 Or ObjProduct.Parent2 = 925087209 Or ObjProduct.Parent2 = 925054070 Or ObjProduct.Parent2 = 925602057 Or ObjProduct.Parent2 = 147 Or ObjProduct.Parent2 = 925757 Or ObjProduct.Parent2 = 925886 Or ObjProduct.Parent2 = 925760 Or ObjProduct.Parent2 = 925590675 Or ObjProduct.Parent2 = 925758 Or ObjProduct.Parent2 = 950026 Then


                If Catname.ToString.IndexOf("-", StringComparison.Ordinal) > -1 Then
                    Common.prodLocCity(Catname, Strcity, Strloc, ProdNameNoloc)
                    If Strloc <> "" Then
                        Revcount = ProdNameNoloc.Trim & ", " & Strloc.Trim
                    Else
                        Revcount = ProdNameNoloc.Trim & ", " & Strcity
                    End If
                Else
                    Revcount = Catname
                End If
            Else
                Revcount = Catname
                dvAddr.Visible = False
            End If
            If litcustaddr.Text = "" Then
                dvadricon.Visible = False
                dvAddr.Visible = False
            End If
            If (ObjProduct.CatId = 925668117 Or ObjProduct.CatId = 925704018) Or (ObjProduct.CatId = 925087287) Then
                If Session("id") <> 0 Then
                    CheckCorp = DAL.ExecuteScalar("select corpid from ms_corp_products where cat_id=" & ObjProduct.CatId).ToString.Equals(Session("id").ToString)
                End If
                Dim corpDs As DataSet
                If CheckCorp = False Then
                    corpDs = DAL.ExecuteDataset("UPDATE_PRODUCT_RATINGS_cs " & ObjProduct.CatId.ToString & ",0")
                Else
                    corpDs = DAL.ExecuteDataset("UPDATE_PRODUCT_RATINGS_cs " & ObjProduct.CatId.ToString & ",1")
                End If
                lblProductRating.Text = Product.ProdRatingSprites(CType(corpDs.Tables(1).Rows(0)(0), Double))
                lblRecommendation.Text = CType((corpDs.Tables(0).Rows(0)(0) & "%"), String)
                litonlyrevcnt.Text = corpDs.Tables(2).Rows(0)(0).ToString & " Reviews"
                NorRevCnt = CType(corpDs.Tables(2).Rows(0)(0), Integer)
                Ratingcnt = CType(corpDs.Tables(1).Rows(0)(0), Double)
            End If
            If NorRevCnt <> 0 Then
                lnkrevcnt.HRef = Mshost & Movielink & Common.ConvertToURLString1(Strcatname) & "-reviews-" & Cid & "#dvreview-listing"
            End If
            liAllReviews.Attributes.Add("title", NorRevCnt & " reviews for " & Strcatname)
            _jsonLdSnippetProduct = Product.GetJsonLdSnippetProduct(Ratingcnt, NorRevCnt, Cid, ObjProduct.Advice, "$catname$", _strHeaderContent)

        End Sub
        Protected Function populate_user_details() As Boolean
            Try
                Dim objproddet As Object
                objproddet = Product_Details.GetProdDet(Cty, CType(Session("id"), Integer), CType(Cid, Integer))
                If objproddet.address = "" AndAlso objproddet.city = "" Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Property DeletedReview() As Boolean
            Get
                Return IsDeletedReview
            End Get
            Set(ByVal value As Boolean)
                IsDeletedReview = value
            End Set
        End Property
        Public Property StrHeaderContent() As String
            Get
                Return _strHeaderContent
            End Get
            Set(ByVal value As String)
                _strHeaderContent = value
            End Set
        End Property
        Public Property ProductJsonLdSnippet() As String
            Get
                Return _jsonLdSnippetProduct
            End Get
            Set(ByVal value As String)
                _jsonLdSnippetProduct = value
            End Set
        End Property
        Public Property Cidforcontrol() As Long
            Get
                Return Cid
            End Get
            Set(ByVal value As Long)
                Cid = value
            End Set
        End Property
        Public Property Mergedprodsforcontrol() As String
            Get
                Return Mergedprods
            End Get
            Set(ByVal value As String)
                Mergedprods = value
            End Set
        End Property
        Public Property mergedprods_new() As Boolean
            Get
                Return IsmergeNew
            End Get
            Set(ByVal value As Boolean)
                IsmergeNew = value
            End Set
        End Property
        Public Property Readalltype() As String
            Get
                Return StrReadAlltype
            End Get
            Set(ByVal value As String)
                StrReadAlltype = value
            End Set
        End Property
        Public Property setreadreviewid() As Long
            Get
                Return Readreviewid
            End Get
            Set(ByVal value As Long)
                Readreviewid = value
            End Set
        End Property
        Public Property verifiedreviewid() As String
            Get
                Return verified_reviewid
            End Get
            Set(ByVal value As String)
                verified_reviewid = value
            End Set
        End Property
        Public Property verified_edit_review() As Integer
            Get
                Return EditVerRev
            End Get
            Set(ByVal value As Integer)
                EditVerRev = value
            End Set
        End Property
        Public Property general_edit_review() As Integer
            Get
                Return GenVerRev
            End Get
            Set(ByVal value As Integer)
                GenVerRev = value
            End Set
        End Property
        Private Sub displayaddressandphone()
            Dim catid As Long = ObjProduct.CatId
            Dim subcat As Long = ObjProduct.Level1
            Dim maincat As Long = ObjProduct.Parent
            Dim ds As DataSet = Product.getSpecs(CType(catid, Integer), CType(maincat, Integer), CType(subcat, Integer))
            Dim stradr_re = ""
            Dim pat As String = "(8)(19)(15)(14)(13)(12)(11)(10)(21)(157)(925593078)(6)(9)"
            Dim pat1 As String = "(950026)(925602057)(925590675)(925758)"
            Dim r As Regex = New Regex(pat, RegexOptions.IgnoreCase)
            Dim r1 As Regex = New Regex(pat, RegexOptions.IgnoreCase)
     
            If r.Match(ObjProduct.Parent.ToString()).Success Or r1.Match(ObjProduct.Parent2.ToString()).Success Then
                StrReadAlltype = "Normal"
            End If
            If ObjProduct.Parent = "8" Or ObjProduct.Parent = "19" Or ObjProduct.Parent = "15" Or ObjProduct.Parent = "14" Or ObjProduct.Parent = "13" Or ObjProduct.Parent = "12" Or ObjProduct.Parent = "11" Or ObjProduct.Parent = "10" Or ObjProduct.Parent = "21" Or ObjProduct.Parent = "157" Or ObjProduct.Parent = "925593078" Or (ObjProduct.Parent = 6 And ObjProduct.Parent2 = 950026) Or (ObjProduct.Parent = 9 And (ObjProduct.Parent2 = 925602057 Or ObjProduct.Parent2 = 925590675 Or ObjProduct.Parent2 = 925758)) Then
                StrReadAlltype = "Normal"
            End If
            If ds.Tables.Count > 1 AndAlso Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                IsCustomTable = True
                If ds.Tables(1).Select("show=1 and colname='Registered Office Address'").Length > 0 And ds.Tables(0).Columns.Contains("Registered Office Address").ToString().ToLower() Then
                    stradr_re = ds.Tables(0).Rows(0).Item("Registered Office Address").ToString()
                ElseIf ds.Tables(1).Select("show=1 and colname='Address'").Length > 0 And ds.Tables(0).Columns.Contains("Address").ToString().ToLower() Then
                    stradr_re = ds.Tables(0).Rows(0).Item("Address").ToString()
                Else
                    dvadricon.Visible = False
                    dvAddr.Visible = False
                End If
                If ds.Tables(1).Select("show=1 and colname='Contact Number'").Length > 0 And ds.Tables(0).Columns.Contains("Contact Number").ToString().ToLower() Then
                    litcusttel.Text = ds.Tables(0).Rows(0).Item("Contact Number").ToString()
                    If litcusttel.Text <> "" Then
                        dvAddress.Visible = True
                        dvtel.Visible = True
                        If stradr_re.Trim = "" Then
                            dvadricon.Visible = False
                        End If
                    End If
                ElseIf ds.Tables(1).Select("show=1 and colname='Contact'").Length > 0 And ds.Tables(0).Columns.Contains("Contact").ToString().ToLower() Then
                    litcusttel.Text = ds.Tables(0).Rows(0).Item("Contact").ToString()
                    If litcusttel.Text <> "" Then
                        dvAddress.Visible = True
                        dvtel.Visible = True
                        If stradr_re.Trim = "" Then
                            dvadricon.Visible = False
                        End If
                    End If
                End If

                If ds.Tables(1).Select("show=1 and colname='Class'").Length > 0 And ds.Tables(0).Columns.Contains("Class").ToString().ToLower() Then
                    lithotelclass.Text = ds.Tables(0).Rows(0).Item("Class").ToString()
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("Class")) Then
                        lithotelclass.Text = Common.returnHotelClass(CType(ds.Tables(0).Rows(0).Item("Class").ToString(), Decimal))
                        If lithotelclass.Text <> "" Then dvclass.Visible = True
                    End If
                End If
                If ObjProduct.Parent = 19 Then
                    If ds.Tables(1).Select("show=1 and colname='Board Type'").Length > 0 And ds.Tables(0).Columns.Contains("Board Type").ToString().ToLower() Then
                        LitBrandname.Text = ds.Tables(0).Rows(0).Item("Board Type").ToString()
                        spnBrandIcon.Style.Add("background-position", "-160px -75px;")
                        spnBrandIcon.Style.Add("width", "20px;")
                        dvbrand.Visible = True
                        dvAddress.Visible = True
                    End If
                    If litcusttel.Text = "" Then
                        If stradr_re.Trim = "" Then
                            dvadricon.Visible = False
                        End If
                        dvAddr.Visible = False
                    End If
                End If

                'Brand for issue no. 11602 
                If ds.Tables(1).Select("show=1 and colname='Brand'").Length > 0 And ds.Tables(0).Columns.Contains("Brand").ToString().ToLower() Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("Brand")) Then
                        LitBrandname.Text = ds.Tables(0).Rows(0).Item("Brand").ToString()
                        dvbrand.Visible = True
                        dvAddress.Visible = True
                    End If
                End If

                If ds.Tables(1).Select("show=1 and colname='Price (in INR)'").Length > 0 And ds.Tables(0).Columns.Contains("Price (in INR)").ToString().ToLower() Then
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item("Price (in INR)")) AndAlso ds.Tables(0).Rows(0).Item("Price (in INR)") <> "0" Then
                        Dim price As String = ds.Tables(0).Rows(0).Item("Price (in INR)").ToString()
                        lblPrice.InnerText = Common.getCurrencyFormat(price)
                        dvPrice.Visible = True
                        dvAddress.Visible = True
                        If Parent21 = "102" Or Parent21 = "101" Then
                            ltrExShowroom.Text = "<small>(Ex-Showroom)</small>"
                            btnGetQuote.Visible = True
                        Else
                            ltrExShowroom.Text = "<small>(Launch price)</small>"
                        End If
                    End If
                End If

            End If
            stradr_re = Regex.Replace(stradr_re, "(((upper )|(lower ))*(ground floor)+(,)*)", "", RegexOptions.IgnoreCase)
            litcustaddr.Text = stradr_re
            If stradr_re <> "" Then
                dvAddr.Visible = True
                dvAddress.Visible = True
            End If
        End Sub
  
        Public Sub processData()
           Dim dscustom As DataSet
            If Mergedprods <> "" Then
                If IsmergeNew = True Then
                    dscustom = DAL.ExecuteDataset("select count(mr.review_id) as 'cnt',min(mca.ms_date) as 'mindate', max(mca.ms_date) as 'maxdate' from ms_review" & Common.SuffixDomain & " mr, ms_common_answers" & Common.SuffixDomain & " mca where mr.cat_id=" & Cid & " and mr.review_id=mca.rid")
                Else
                    dscustom = DAL.ExecuteDataset("select count(mr.review_id) as 'cnt',min(mca.ms_date) as 'mindate', max(mca.ms_date) as 'maxdate' from ms_review" & Common.SuffixDomain & " mr, ms_common_answers" & Common.SuffixDomain & " mca where mr.cat_id in (" & Mergedprods & ") and mr.review_id=mca.rid")
                End If
            Else
                dscustom = DAL.ExecuteDataset("select count(mr.review_id) as 'cnt',min(mca.ms_date) as 'mindate', max(mca.ms_date) as 'maxdate' from ms_review" & Common.SuffixDomain & " mr, ms_common_answers" & Common.SuffixDomain & " mca where mr.cat_id=" & Cid & " and mr.review_id=mca.rid")
            End If
            
            Totcount = CType(dscustom.Tables(0).Rows(0)("cnt"), Integer)
            If Totcount > 0 Then
                MindateforAnalyse = Year(dscustom.Tables(0).Rows(0)("mindate"))
                MaxDateforAnalyse = Year(dscustom.Tables(0).Rows(0)("maxdate"))

            End If

        End Sub

        Public Function validateEmail(ByVal emailAddress As String) As Boolean
            Dim email As New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            If email.IsMatch(emailAddress) Then
                Return True
            Else
                Return False
            End If
        End Function
        Protected Sub btnGetPrice_Click(sender As Object, e As EventArgs) Handles btnGetPrice.Click
            Try
                If txtName.Text = "" Or txtMail.Text = "" Or txtMob.Text = "" Then
                    dvQuoteError.InnerText = "Fields marked with * are mandatory."
                    dvQuoteError.Style.Add("display", "block")
                ElseIf validateEmail(txtMail.Text) = False Then
                    dvQuoteError.InnerText = "Invalid Email Id."
                    dvQuoteError.Style.Add("display", "block")
                ElseIf txtMob.Text.Length < 10 Then
                    dvQuoteError.InnerText = "Invalid Mobile Number."
                    dvQuoteError.Style.Add("display", "block")
                Else

                    DAL.ExecuteNonQuery(CType(("insert into tbl_onRoadPrice ([user_id],[Name],[Email],[Number],[ModelName],[cat_id],[PinCode],[Location],[parent2],[ms_date]) " &
                                               " values (" & CType(Session("id"), String) & ",'" & txtName.Text.Replace("'", "''") & "','" & txtMail.Text & "'," & txtMob.Text & ",'" & txtModel.Value.Replace("'", "''") & "'," & ObjProduct.CatId.ToString() & "," & IIf(txtPinCode.Text.ToString() <> "", txtPinCode.Text.ToString(), "0") & ",'" & txtCity.Text.ToString() & "'," & ObjProduct.Parent2.ToString & ",getDate())"), String))
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "thankyouModal", "openThankYouModal()", True)

                End If
            Catch ex As Exception
                Logger.WriteError("Error in btnSubmit_Click", ex)
            End Try
        End Sub
        Private Sub getshareoption()

            If Mergedprods <> "" And IsmergeNew = False Then
                Dim ssql = "select top 1 mds.recommendation, mds.rating, coalesce( md.twitter, '') as 'twitter' from ms_data_srch mds, ms_data md where md.cat_id = mds.cat_id and mds.cat_id in (" & Mergedprods & ") and mds.cat_id = mds.merge_parent"
                Dim ds As DataSet
                ds = DAL.ExecuteDataset(ssql)
                Recommendationcnt = CType(ds.Tables(0).Rows(0)("recommendation"), Integer)
                _twitter = CType(ds.Tables(0).Rows(0)("twitter"), String)
                Ratingcnt = CType(ds.Tables(0).Rows(0)("rating"), Double)
            End If

            Dim strname As String = Catname
            If Catname.ToString.Length > 35 Then
                strname = Catname.Substring(0, 35) & ".."
            End If

            If Readreviewid <> 0 Then
                If Deleted = True Then
                    If Isadvice = True Then
                        TweetTitle = CType(("#Review on " & IIf(_twitter = "", "#" & strname, _twitter) & " by Anonymous : " & _reviewtitle), String)
                    Else
                        If Session("name") = _reviewauthor Then
                            TweetTitle = CType(("I reviewed " & IIf(_twitter = "", "#" & strname, _twitter) & " as " & _reviewrating & "/5.  Earn Rs.40 per review #MouthShut #WriteShareWin"), String)
                        Else
                            TweetTitle = CType(("I found this review of " & IIf(_twitter = "", "#" & strname, _twitter) & " pretty useful #MouthShut"), String)
                        End If
                        'tweetTitle = reviewrating & "/5 " & "#Review on " & IIf(twitter = "", "#" & Common.twitter_formatcatname(catname), twitter) & " by Anonymous : " & reviewtitle
                    End If
                Else
                    If Isadvice = True Then
                        TweetTitle = CType(("#Review on " & IIf(_twitter = "", "#" & strname, _twitter) & " by " & _reviewauthor & " : " & _reviewtitle), String)
                    Else
                        If Session("name") = _reviewauthor Then
                            TweetTitle = CType(("I reviewed " & IIf(_twitter = "", "#" & strname, _twitter) & " as " & _reviewrating & "/5.  Earn Rs.40 per review #MouthShut #WriteShareWin"), String)
                        Else
                            TweetTitle = CType(("I found this review of " & IIf(_twitter = "", "#" & strname, _twitter) & " pretty useful #MouthShut"), String)
                        End If
                    End If
                End If

            Else
                If Isadvice = True Then
                    TweetTitle = CType((IIf(_twitter = "", "#" & strname, _twitter) & " #Reviews - MouthShut.com"), String)
                Else
                    TweetTitle = CType(("Thought I'd share " & IIf(_twitter = "", "#" & strname, _twitter) & " rating #MouthShut"), String)
                    'tweetTitle = (ratingcnt & "/5 " & IIf(twitter = "", "#" & Common.twitter_formatcatname(catname), twitter) & " #Reviews - Recommended by " & recommendationcnt & "% members - MouthShut.com")
                End If
            End If
            If Request.Url.AbsoluteUri.ToString.IndexOf("lyrics.aspx", StringComparison.Ordinal) <> -1 OrElse Request.Url.AbsoluteUri.ToString.IndexOf("lyricspermalink.aspx", StringComparison.Ordinal) <> -1 Then
                TweetTitle = CType(("All Songs #Lyrics and Videos from " & IIf(_twitter = "", "#" & strname, _twitter)), String)
            End If
            'If tweetTitle.Length > 98 Then
            '    tweetTitle = tweetTitle.Substring(0, 98)
            'End If


            FshareTweet.isadvice = Isadvice
            FshareTweet.strTweetTitle = TweetTitle
            FshareTweet.canUrl = CType(Session("backurl"), String)
            FshareTweet.gplus = True
            FshareTweet.catid = Cid
            FshareTweet.readallmail = True
            FshareTweet.readalltype = StrReadAlltype

        End Sub
        Private Sub getcategoryname()

            Dim strH1 As String = CType(DAL.ExecuteScalar("select seo_h1 from ms_seo_description_in_bak where cat_id=" & CType(Cid, String) & " and page_id=3"), String)
            If Request.Url.AbsoluteUri.ToLower.IndexOf("/review/readproduct.php", StringComparison.Ordinal) > -1 Then
                If strH1 <> "" Then
                    litprodtitle.Text = strH1
                    litAutoprodtitle.Text = strH1
                Else
                    If _parent2 = "925235" And (_level1Hierarcy.ToString.Contains("categories.php?cid=925816") Or _level1Hierarcy.ToString.Contains("categories.php?cid=925243")) Then
                        litprodtitle.Text = Catname
                        litAutoprodtitle.Text = Catname
                    Else
                        If Parent1 = 19 Then
                            If Catname.ToString.IndexOf("-", StringComparison.Ordinal) > -1 Then
                                Dim loc As String = Catname.Substring(Catname.LastIndexOf("-", StringComparison.Ordinal) + 1)
                                Dim prodName_Noloc As String = Catname.Substring(0, Catname.LastIndexOf("-", StringComparison.Ordinal))
                                litprodtitle.Text = prodName_Noloc.Trim & " " & loc.Trim
                                litAutoprodtitle.Text = prodName_Noloc.Trim & " " & loc.Trim

                            Else
                                litprodtitle.Text = Catname
                                litAutoprodtitle.Text = Catname

                            End If
                        Else
                            litprodtitle.Text = Catname
                            litAutoprodtitle.Text = Catname
                        End If
                    End If
                End If
            Else
                litprodtitle.Text = Catname
                litAutoprodtitle.Text = Catname
                If (Request.Url.AbsoluteUri.ToLower.IndexOf("/review/productphotos.aspx", StringComparison.Ordinal) > -1 Or Request.Url.AbsoluteUri.ToLower.IndexOf("product/restaurantphotos.aspx", StringComparison.Ordinal) > -1) Then
                    If _parent2 = 925071706 Or _parent2 = 925039310 Or _parent2 = 925236 Or _parent2 = 925235 Then
                        lttype.Text = " Photos & Trailers"
                    Else
                        lttype.Text = " Photos"
                    End If
                ElseIf Request.Url.AbsoluteUri.ToLower.IndexOf("product/product_discussion.aspx", StringComparison.Ordinal) > -1 Then
                    lttype.Text = " Q & A"
                Else
                    lttype.Text = ""
                End If
            End If

            If Request.Url.AbsoluteUri.ToLower.IndexOf("review/readreview.php", StringComparison.Ordinal) > -1 Then
                litprodtitle.Text = Catname
                litAutoprodtitle.Text = Catname
                'If (Request.Url.AbsoluteUri.ToLower.IndexOf("/review/productphotos.aspx") > -1 Or Request.Url.AbsoluteUri.ToLower.IndexOf("product/restaurantphotos.aspx") > -1) Then
                '    lttype.Text = "Photos"
                'ElseIf Request.Url.AbsoluteUri.ToLower.IndexOf("product/product_discussion.aspx") > -1 Then
                '    lttype.Text = "Q and A"
                'Else
                '    lttype.Text = ""
                'End If
                lttype.Text = ""
            End If

            If Parent1 = 7 Or Parent1 = 19 Or (Parent1 = 18 And Level1 <> 925153) Or (Parent1 = 8 And _parent2 <> 925069787) Or _parent2 = 925593078 Or _parent2 = 925062123 Or _parent2 = 925040057 Or _parent2 = 925087251 Or _parent2 = 925087190 Or _parent2 = 925087209 Or _parent2 = 925054070 Or _parent2 = 925602057 Or _parent2 = 147 Or _parent2 = 925757 Or _parent2 = 925886 Or _parent2 = 925760 Or _parent2 = 925590675 Or _parent2 = 925758 Or _parent2 = 950026 Or _parent2 = 925758435 Then
                If Catname.ToString.IndexOf("-", StringComparison.Ordinal) > -1 Then
                    Common.prodLocCity(Catname, Strcity, Strloc, ProdNameNoloc)
                    litprodtitle.Text = ProdNameNoloc.Trim
                    litAutoprodtitle.Text = ProdNameNoloc.Trim
                    If Strloc <> "" Then
                        litlocality.Text = ", " & Strloc.Trim & ", " & Strcity
                        litAutolocality.Text = ", " & Strloc.Trim & ", " & Strcity
                    Else
                        litlocality.Text = ", " & Strcity
                        litAutolocality.Text = ", " & Strcity

                    End If


                    If (Request.Url.AbsoluteUri.ToLower.IndexOf("/review/productphotos.aspx", StringComparison.Ordinal) > -1 Or Request.Url.AbsoluteUri.ToLower.IndexOf("product/restaurantphotos.aspx", StringComparison.Ordinal) > -1) Then

                        If _parent2 = 925071706 Or _parent2 = 925039310 Or _parent2 = 925236 Or _parent2 = 925235 Then
                            lttype.Text = " Photos & Trailers"
                        Else
                            lttype.Text = " Photos"
                        End If

                    ElseIf Request.Url.AbsoluteUri.ToLower.IndexOf("product/product_discussion.aspx", StringComparison.Ordinal) > -1 Then
                        lttype.Text = " Q & A"
                    Else
                        lttype.Text = ""
                    End If
                End If
            End If
            _productName = litAutoprodtitle.Text & litAutolocality.Text
        End Sub
        Private Sub BindSpecification()
            Try

                If ObjProduct.Parent = 7 Or ObjProduct.Parent2 = 145 Then
                    If ObjProduct.Parent2 = 101 AndAlso Request.Url.PathAndQuery.ToString.Contains("readproduct.php") AndAlso ObjProduct.CatId <> ObjProduct.MergeParent Then

                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub BindStarRating()
            Try
                Dim txtfilepath = ConfigurationManager.AppSettings("ImageServerPhysicalPath") & cachepath & "\customheader\" & ObjProduct.CatId & ".txt"

                If CachingStatus = 0 OrElse EnableReviewsCache = False Then


                    Dim iscorprev As Integer
                    Dim strreviewsforrating As String
                    If Mergedprods <> "" Then
                        iscorprev = CType(DAL.ExecuteScalar("Select mr.user_id from ms_review mr, ms_user mu where mr.cat_id in (" & Mergedprods & ") and  mr.user_id = mu.user_id and mu.iscorporate=1 and mu.user_id in (select corpid from ms_corp_products where cat_id =" & ObjProduct.CatId & ")"), Integer)
                    Else
                        iscorprev = CType(DAL.ExecuteScalar("Select mr.user_id from ms_review mr, ms_user mu where mr.cat_id=" & ObjProduct.CatId & " and  mr.user_id = mu.user_id and mu.iscorporate=1 and mu.user_id in (select corpid from ms_corp_products where cat_id =" & ObjProduct.CatId & ")"), Integer)
                    End If

                    If Mergedprods <> "" Then
                        If IsmergeNew = True Then
                            strreviewsforrating = ReadWrite.getreviews(CType(Cid, String), CType(Session("id"), Integer), iscorprev)
                        Else
                            strreviewsforrating = ReadWrite.getreviews(Mergedprods, CType(Session("id"), Integer), iscorprev)
                        End If
                    Else
                        strreviewsforrating = ReadWrite.getreviews(CType(Cid, String), CType(Session("id"), Integer), iscorprev)
                    End If

                    Dim objUniqueQid = ReadWrite.GetUniqueQid(Cid)

                    'changed on 04/05/2015
                    If Not objUniqueQid Is Nothing Then
                        If IsmergeNew = True Then
                            Call Product.GetUniqueQuestions(objUniqueQid, ArrRatingQuestion, strreviewsforrating, "")
                        Else
                            Call Product.GetUniqueQuestions(objUniqueQid, ArrRatingQuestion, strreviewsforrating, Mergedprods)
                        End If
                    End If
                    'end
                    Dim i As Integer


                    For i = 1 To ArrRatingQuestion.Count
                        If i Mod 2 <> 0 Then
                            litrating1.Text += "<div class=""row""> <div class=""col-6""> <div class=""row""> <div class=""col-4""><p>" + ArrRatingQuestion.Item(i - 1).QuestionText.ToString + "</p></div> " +
                                               "<div class=""col-8 express-ratings""> " + Rating(CType(ArrRatingQuestion.Item(i - 1).Rating.ToString, Integer), NorRevCnt) + " </div></div></div>"
                            If i = ArrRatingQuestion.Count Then
                                litrating1.Text += "</div>"
                            End If
                        ElseIf (i Mod 2 = 0) Or (i <> ArrRatingQuestion.Count) Then
                            litrating1.Text += "<div class=""col-6""> <div class=""row""> <div class=""col-4""><p>" + ArrRatingQuestion.Item(i - 1).QuestionText.ToString + "</p></div> " +
                                               "<div class=""col-8 express-ratings""> " + Rating(CType(ArrRatingQuestion.Item(i - 1).Rating.ToString, Integer), NorRevCnt) + " </div></div></div></div>"

                        End If

                    Next
                End If
                If CachingStatus = 1 AndAlso EnableReviewsCache = True Then
                    If File.Exists(txtfilepath) Then
                        Dim myFileStream As New System.IO.FileStream(txtfilepath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
                        Dim myReader As New System.IO.StreamReader(myFileStream)
                        litrating1.Text = myReader.ReadToEnd()
                        myReader.Close()
                        myFileStream.Close()
                        Exit Sub
                    Else
                        Using fs As FileStream = System.IO.File.Create(txtfilepath)

                            Dim info As Byte() = New UTF8Encoding(True).GetBytes(litrating1.Text)
                            fs.Write(info, 0, info.Length)
                        End Using
                        DAL.ExecuteNonQuery("if exists( select 1 from  ms_Caching_Track (nolock) where cat_id= " & Cid & " ) update ms_Caching_Track set status1=1 where cat_id= " & Cid & " else Insert into ms_Caching_Track ([cat_id],[status1]) values(" & Cid & ",1)")

                    End If
                Else
                    If EnableReviewsCache = True Then
                        Using fs As FileStream = System.IO.File.Create(txtfilepath)

                            Dim info As Byte() = New UTF8Encoding(True).GetBytes(litrating1.Text)
                            fs.Write(info, 0, info.Length)
                        End Using
                        DAL.ExecuteNonQuery("if exists( select 1 from  ms_Caching_Track  (nolock) where cat_id= " & Cid & " ) update ms_Caching_Track set status1=1 where cat_id= " & Cid & " else Insert into ms_Caching_Track ([cat_id],[status1]) values(" & Cid & ",1)")

                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub
        Public Shared Function Rating(ByVal ratingValue As Integer, ByVal revieCount As Integer) As String
            Dim ratingString As String = ""
            Dim i As Integer

            If ratingValue < 1 AndAlso revieCount >= 1 Then
                ratingValue = 1
            End If

            If ratingValue = 1 Or ratingValue = 2 Then
                For i = 1 To ratingValue
                    ratingString = ratingString & "<div class=""bgcolor-1""></div> "
                Next

            ElseIf ratingValue = 3 Then
                For i = 1 To ratingValue
                    ratingString = ratingString & "<div class=""bgcolor-3""></div> "
                Next

            ElseIf ratingValue = 4 Or ratingValue = 5 Then
                For i = 1 To ratingValue
                    ratingString = ratingString & "<div class=""bgcolor-5""></div> "
                Next
            End If

            ' colored star
            For i = ratingValue + 1 To 5
                ratingString = ratingString & "<div class=""unrated-unirating""></div> "
            Next

            Return ratingString
        End Function

    End Class
End Namespace