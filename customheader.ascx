<%@ Control Language="VB" AutoEventWireup="false" CodeFile="customheader.ascx.vb" Inherits="INCLUDES.Controls.IncludesControlsCustomheader" EnableViewState="false" %>

<%@ Register Src="~/Includes/Controls/Hierarchy.ascx" TagName="Hierarchy" TagPrefix="uc2" %>

<%@ Register TagPrefix="UC" TagName="FshareTweet" Src="~/INCLUDES/Controls/UCFshareTweet_New.ascx" %>
<style>    
    .twverify {
        background: url(http://www.mouthshut.com/images/read-readall.png) no-repeat; background-position: -197px -85px;
        width: 20px;
        height: 20px;
        display: inline-block;
        cursor:pointer;margin-top: 12px;
    }
    .twverify .tooltip-content{
        margin-top: 0!important;   
    }
</style>
<div class="page-header" id="top1">
    <div class="col-12">
            <uc2:Hierarchy ID="Hierarchy1" runat="server" />
            <div class="table">
            <%If Request.Url.PathAndQuery.ToLower.Contains("readreview.php") Then%>
                <div class="rrhead pull-left" id="prodTitle">
                    <h1><%=strreviewtitle%> 
                        <span class="review-prod-title">Review on 
                        <a href="<%=mshost & movielink & Common.ConvertToURLString1(Strcatname)%>-reviews-<%=Cid%>">
                            <asp:Literal ID="litprodtitle" runat="server" /><asp:Literal ID="litlocality" runat="server" />
                        </a>
                        
                    </span>
                                         </h1>
                    <%If iscorpproduct <> "" Then%>
                    <a target="_blank" href="<%=mshost %>business"><span class="twverify tooltip right" id="spnverified1" runat="server" visible="false"><span class="tooltip-content" style="display: none;">MouthShut Verified Product</span></span></a>
                    <%End If%>
                </div>
                
            <% Else%>
                <h1 id="prodTitle1" class="pull-left bighead-rr">
                    <a href="<%=mshost & movielink & Common.ConvertToURLString1(Strcatname)%>-reviews-<%=Cid%>"><asp:Literal ID="litAutoprodtitle" runat="server" /><asp:Literal ID="litAutolocality" runat="server" /></a><span style="color: #71a117;"><asp:Literal ID="lttype" Text="" runat="server" /></span>
                </h1>
                <%If iscorpproduct <> "" Then%>
                <a target="_blank" class="pull-left" href="<%=mshost %>business"><span class="twverify tooltip right" id="spnverified" runat="server" visible="false"  ><span class="tooltip-content" style="display: none;">MouthShut Verified Product</span></span>
                    </a>
                <%End If%>
            <%End If%>
            
            <span id="spnshare" class="pull-right" onclick="javascript:toggle_visibility();" style="position:relative;" >
                <span>
                    <button class="btn btn-link right share" type="button" style="margin-bottom: 10px;"><span class="icon-share"></span>Share</button>
                </span>
                <span class="dropdown-tip" id="ddShare" style="display:none">                    
                    <UC:FshareTweet marginTop="true" ID="FshareTweet" runat="server" />
                </span>
            </span>
                
                </div>
            
        </div>
    </div>
<div class="cust-head-top">
<%If lt.Value <> "" And lt.Value <> "0" Then%>
<script type ="text/javascript" src="http://maps.googleapis.com/maps/api/js"></script>
<%End If%>
<style>
    .widget-box span {
        padding-left: 0 !important;
    }
    .imgWARPopUp {
            position: absolute;
    top: 200px;
    z-index: 9999;
    text-align: center;
    width: 300px;
    height: 215px;
    left: 0;
    right: 0;
    margin: auto;
        }
    .imgPastePrevent {position: fixed;top: 200px;z-index: 9999;text-align: center;width: 450px;height: 250px;left: 0;right: 0;margin: auto;}
</style>
<%  If (Request.Browser.Version.ToString.ToLower = "8.0" Or Request.Browser.Version.ToString.ToLower = "7.0") Then%>
<style type="text/css">
    ul.product-title li.ratings ul {
        list-style: none;
        list-style-type: none;
        padding: 0;
        margin: 0;
        display: none;
        position: absolute;
        overflow: hidden;
        padding: 10px;
        margin: 0 0 0 -175px;
        background-color: #f8f8f8;
        float: right;
        border: solid #bcbcbc 1px;
    }
</style>
<%End If%>



<input id="hidReviewId" type="hidden" />
<input type="hidden" runat="server" id="lt" />
<input type="hidden" runat="server" id="lngd" />
 
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<% If (parent21 = "102" Or parent21 = "101") Then%>
    <div class="get-quote hide" id="getQuote">
    <p class="modal-head">Get On Road Price</p>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div role="alert" id="dvQuoteError" style="display: none;" runat="server" class="alert alert-danger"></div>
                <div class="col-6">
                    <span class="field-outline">
                        <asp:TextBox type="text" ID="txtName" runat="server" placeholder="Name *"></asp:TextBox>
                    </span>
                    <span class="field-outline">
                        <asp:TextBox type="text" ID="txtMob" runat="server" placeholder="Mobile Number *" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </span>
                    <span class="field-outline">
                        <asp:TextBox type="text" ID="txtMail" runat="server" placeholder="E-Mail *"></asp:TextBox>
                    </span>
                </div>
                <div class="col-6">
                    <span class="field-outline">
                        <input type="text" id="txtModel" runat="server" disabled>
                    </span>
                    <span class="field-outline">
                        <asp:TextBox type="text" ID="txtPinCode" runat="server" placeholder="Pin Code" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </span>
                    <span class="field-outline">
                        <asp:TextBox type="text" ID="txtCity" runat="server" placeholder="City"></asp:TextBox>
                    </span>
                </div>
            </div>
            <div class="text-center">
                <asp:Button ID="btnGetPrice" ClientIDMode="Static" runat="server" class="btn btn-primary quote" OnClientClick="return validateQuoteForm()" Text="Get On Road Price" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGetPrice" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


</div>
    <div id="dvThankQuote" class="row hide">
        <div class="thank-quote text-center">
            <p class="modal-head">Get On Road Price</p>
            <p><span class="icon-verify"></span></p>
            <p style="font-size:16px"><strong>Thank you for sharing the requirements with us. We'll contact you shortly.</strong></p>
        </div>
    </div>
<%End If%>


<div id="loader" class="hide">
    <div style="background-color: #fff ; margin-top:30px;" class="ajaxloader" align="center">
        <img alt="" src="/Images/COMMON/loading_ajax.gif">
    </div>
        </div>

<div class="row">
    <div class="col-4">
        <div class="product-images" id="prodImg" runat="server">
            <div id="dvDelStamp" runat="server" visible="false"></div>
            <div class="row" id="divdealmap" style="display: none">
                <div id='dealmap' style="max-width: 370px; width:100%; height: 240px"></div>
            </div>
            <a runat="server" id="lnkProductImage">
                <asp:Image ID="imgproduct" runat="server" alt="" Style="cursor: pointer" />
                <asp:Image ID="imgClosedDiscontinued" class="discontinuedprd" runat="server" Visible="false" />
            </a>

        </div>
        <% If objProduct.Advice = True Then%>
        <div class="reviews">
            <a href="<%=mshost & movielink & Common.ConvertToURLString1(Strcatname)%>-reviews-<%=Cid%>#dvreview-listing">
                <asp:Literal runat="server" ID="adviceCount"></asp:Literal>
                Tips
            </a>

            <% Else%>
            <div class="product-info">
                <%End If%>

                <button class="btn btn-secondary" id="btnwritereview" runat="server" type="button">
                    <span class="icon-write-review"></span>
                    <span id="lblwritereview" runat="server">Write Review</span></button>

                <% If objProduct.Advice = True Then%>
            </div>
            <% Else%>
        </div>
        <%End If%>
    </div>


    <div class="col-8" id="dvCusHead" runat="server">
       
        <div class="product-details">
             <div class="highlight-head">
            <h2 style="margin-top: 10px;" class="pull-left">MouthShut Score</h2>
            <div class="pull-right selectbox-container analyse-dropdown" id="dvAnalysedropdown">
                                            <select id="analyse_dropdown" onchange="analyseYearChanged()"></select>
                                            <span class="icon-drop-down"></span>
                                        </div>
            </div>
            <div id="staticdiv" runat="server">
            <div class="module bbnone">
                <div class="module msscore">
                    <div id="dvRecBy" runat="server" class="row review-rating">
                        <div class="ratings text-right">
                            <asp:Literal ID="lblProductRating" runat="server"></asp:Literal>
                        </div>
                        <div class="recommendation " title="Recommended by <%=recommendationcnt%>% members">
                            <span class="icon-like"></span><asp:Literal runat="server" ID="lblRecommendation"></asp:Literal></div>
                        <div class="product-rating" title="<%If ratingcnt < 1 Then%><%=ratingcnt.ToString("0.00")%><%Else%><%=ratingcnt.ToString("#.00").Replace(".00","")%><%End If%>/5.0 Rating for <%=Strcatname%>">
                            <span class="avg-star"><%If ratingcnt < 1 Then%><%=ratingcnt.ToString("0.00")%><%Else%><%=ratingcnt.ToString("#.00").Replace(".00","")%><%End If%>&nbsp;<span class="icon-rating unrated-star"></span></span>
                        </div>
                        <div id="liAllReviews" runat="server" class="reviews">
                            <a href="javascript:void(0)" id="lnkrevcnt" runat="server"><asp:Literal runat="server" ID="litonlyrevcnt"></asp:Literal></a>
                        </div>

                       
                    </div>
                </div>
            </div>
            <div class="module">
                <div class="row summary">
                    <asp:Literal ID="litrating1" runat="server"></asp:Literal>

                </div>
            </div>
                </div>
        </div>
        <div class="product-info" id="dvAddress" runat="server" visible="false">
            <div class="row" id="dvPrice" runat="server" visible="false">
                <div class="prod-range-color pull-left">
                    <p class="price-color">
                        <strong style="color:#333">Rs. <span class="price" id="lblPrice" runat="server"></span></strong>
                        <asp:Literal ID="ltrExShowroom" runat="server"></asp:Literal>
                    </p>
                </div>
                <div id="btnGetQuote" runat="server" visible="false">
                    <button class="btn btn-link" type="button" onclick="openPriceModal(); return false;" id="btnquote">Get On Road Price</button>
                </div>
            </div>

            <div class="row" id="dvAddr" runat="server">
                <p class="info-div">
                    <%If Not objProduct.level1 = 925153 Then%>
                    <span class="icon-location" id="dvadricon" runat="server"></span>
                    <%End If%>
                    <span>
                        <asp:Literal ID="litcustaddr" runat="server" /></span>
                </p>
            </div>
            <div class="row" id="dvbrand" runat="server" visible="false">
                <p class="info-div">
                    <span class="icon-tags" runat="server" id="spnBrandIcon"></span>

                    <span>
                        <asp:Literal ID="LitBrandname" runat="server" /></span>
                </p>
            </div>
            <div class="row" id="dvtel" runat="server" visible="false">
                <p class="info-div">
                    <span class="icon-call"></span>

                    <span>
                        <asp:Literal ID="litcusttel" runat="server" /></span>
                </p>
            </div>

            <div id="dvclass" runat="server" visible="false" class="row">
                <p class="info-div">
                    <span class="icon-hotels"></span>
                    <span>
                        <asp:Literal ID="lithotelclass" runat="server" />
                    </span>
                </p>
            </div>
        </div>


    </div>

</div>



<div id="middle" class="font" style="display: none">

    <div class="font">

        <div style="position: relative;">
            <div>
                <div>

                    <div class="clear"></div>
                    <%If Cid = "925103558" Then%>
                    <div class="disclaimer">
                        <h4>Important Notice and Disclaimer from AO Smith:<span class="downarrow"></span></h4>
                        <p>
                            “Please note that as per the terms of collaboration between AO Smith India Water Products 
                        Private Limited (“AOS”) & [Jaquar and Company Pvt.Ltd] (“Jaquar”) (such collaboration has 
                        ceased with effect from [September 19th 2014]), Jaquar was and is responsible for handling 
                        all service related issues for AOS – Jaquar products. However, as a mark of goodwill and to 
                        prevent any hardships to our customers, AOS is willing to assist the customer in resolving 
                        any service complaint s/he may have for the locations where AOS has its service presence or 
                        coverage. We request the customers of AOS – Jaquar products to contact us directly through the 
                        telephone number or email mentioned in our website <a href="http://www.aosmithindia.com/contactus" rel="nofollow" target="_blank">http://www.aosmithindia.com/contactus</a> to resolve any service related issues 
                        pertaining to the AOS-Jaquar products. However, please note that in providing such service 
                        related assistance, AOS does not assume any liabilities associated with Jaquar.”
                        </p>
                    </div>
                    <%End If%>
                    <div>
                        <div id="dvH" runat="server" class="smallfont" visible="false" style="margin: 10px;">
                            <span class="item vcard">
                                <div>
                                    <%If strReadAlltype = "movie" Then%>
                                    <div class="heading_blue">
                                        <h2 ><span class="fn"><%=objProduct.catname%></span></h2>
                                    </div>
                                    <%End If%>
                                    <span id="SpnRelease" runat="server" style="display: none;"><strong>Release Date:</strong>
                                            <asp:Literal ID="litRelease" runat="server" />
                                    </span><span id="SpnStar" runat="server" style="display: none;"><strong>Star-Cast:</strong>
                                        <asp:Literal ID="litStar" runat="server" />
                                    </span><span id="SpnDirector" runat="server" style="display: none;"><strong>Director:</strong>
                                        <asp:Literal ID="litDirector" runat="server" />
                                    </span><span id="SpnMusic" runat="server" style="display: none;"><strong>Music Director:</strong>
                                        <asp:Literal ID="litMusic" runat="server" />
                                    </span><span id="SpnProducer" runat="server" style="display: none;"><strong>Producer:</strong>
                                        <asp:Literal ID="litProducer" runat="server" />
                                    </span><span id="SpnGenre" runat="server" style="display: none;"><strong>Genre:</strong>
                                        <span>
                                            <asp:Literal ID="litGenre" runat="server" />
                                        </span></span><span id="SpnExtra" runat="server" style="display: none;">
                                            <asp:Literal ID="litExtra" runat="server" />
                                        </span><span id="SpnStoryline" runat="server" style="display: none;">
                                            <asp:Literal ID="litStoryline" runat="server" />
                                        </span><span id="SpnDescription" runat="server" style="display: none;">
                                            <asp:Literal ID="litDescription" runat="server" />
                                        </span><span id="SpnWebpage" runat="server" style="display: none;"><strong>WebPage:</strong>
                                            <asp:Literal ID="litWebpage" runat="server" />
                                        </span>
                                </div>
                            </span>
                        </div>
                    </div>

                </div>
               
            </div>

        </div>
    </div>
    <div class="clear"></div>

    <div class="clear"></div>
    
    <div id="divexpress" style="display: none">
        <div class="confirmationbox">
            <span>Thank you for rating this Product</span>
        </div>
    </div>
    <div id="popuplayer5" class="popuplayer1" style="display: none;">
        <div class="bdr-tb"></div>
        <div class="bdr-lr"></div>
        <div class="top-left"></div>
        <div class="top-right"></div>
        <div class="bottom-right"></div>
        <div class="bottom-left"></div>
        <div class="inner1">
            <div id="expressrev"></div>
        </div>
    </div>
</div>


<script type="text/javascript">
    var arrImg_mp, arrImgCaption_mp;
    var k, k_menu, k_mp, type1;
    var readAlType = "<%=strReadAlltype %>";
    var totalImages, totalImages_menu, totalImages_mp;
    if(readAlType === "movie") {
        var imgServerPath = '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "MoviesMusic/photo/" %>';
        var imgServerPath_menu =
            '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "MoviesMusic/photo/" %>';
        var imgServerPath_mp = '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "ImagesR/" %>';
    }
    else {
        var imgServerPath = '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "Restaurant/Photo/" %>';
        var imgServerPath_menu =
            '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "Restaurant/Menu/" %>';
        var imgServerPath_mp = '<%=ConfigurationManager.AppSettings("ImageServerVirtualPath") & "ImagesR/" %>';
    }
 

    //** For AO Smith Water Heater 925103558 **//        
    $(document).ready(function() {
        $('.black-layer').click(function () {
            $('.imgWARPopUp').hide();
            $('.imgPastePrevent').hide();
            $('.black-layer').css('visibility','hidden');
        });

        $(".disclaimer h4").click(function(){
            $(".disclaimer p").slideToggle('slow',function(){
                $(".downarrow").toggleClass("closearrow");        
            });
        });
        var urldata = document.URL;
        if(urldata.indexOf("#writereviewpanela")>-1 && document.referrer.indexOf("prodsrch.aspx")>-1)
        {
            WriteReview(); return false;
  
        }
        //****//
        // Initialise the first and second carousel by class selector.
        // Note that they use both the same configuration options (none in this case).
        var isbot = '<%=IsBot %>';
        if (isbot === '1' && document.getElementById('specification').innerHTML !== '')
        {
            document.getElementById('specification').style.display='block';
        }
        isdocloaded = 1;
        try{
            jQuery('.first-and-second-carousel').jcarousel({
                visible: 4
            });
        }
        catch(e){}
	
        // If you want to use a caoursel with different configuration options,
        // you have to initialise it seperately.
        // We do it by an id selector here.
        //	jQuery('#third-carousel').jcarousel({
        //        vertical: true
        //    });
    });

    var totCount='<%= totcount%>';
    if (totCount>0)
    {
        var mindate='<%= MindateforAnalyse%>';
        var maxdate='<%= MaxDateforAnalyse%>';            
        var DateRange=maxdate-mindate;
        var i;
               
        //if (DateRange > 0)
        //{
            var option = new Option('Year-wise Rating', '-1'); 
            $('#analyse_dropdown').append($(option));
            for (i = 0;i<=maxdate-mindate;i++)
            {
                option = new Option((maxdate-i).toString(),i); 
                $('#analyse_dropdown').append($(option));
            }
        //}
        //else
        //{
        //    $('#dvAnalysedropdown').hide();
        //}

                    
    }
    else
    {
        $('#dvAnalysedropdown').hide();
    }
</script>

<%--<div id="descrition" class="login_registration" style="display: none;">--%>
    <div id="optionpopup" class="fakeModal hide">
        <div id="dvfakeModal">
            <p class="modal-head text-center">The ingenuineness of this review appears doubtful.<br>
                Justify your opinion.
            </p>
            <div>
            <p>I feel this review is:</p>
           <div class="row radiobtns">
            <div class="radiobox col-6">
                <div class="roundedOne">
                    <span style="position: relative; display: inline-block; font-size: 14px; top: 3px; left: 50px; text-transform: uppercase;">Fake</span>
                    <input type="radio" name="check" id="roundedOne" style="visibility: hidden;" value="None">
                    <label for="roundedOne"></label>
                </div>
            </div>
            <div class="radiobox col-6">
                <div class="roundedTwo">
                    <span style="position: relative; display: inline-block; font-size: 14px; left: 50px; top: 3px; text-transform: uppercase;">Genuine</span>
                    <input type="radio" name="check" id="roundedTwo" style="visibility: hidden;" value="None">
                    <label for="roundedTwo"></label>
                </div>
            </div>
        </div>
            <p>
                <span class="field-outline">
                    <textarea id="txtDAreaComm" placeholder="Justify your opinion..."></textarea>
                </span>
            </p>
            <p class="text-center">
            <input type="button" id="btnSubmitDisc" onclick="javascript:validate();" type="button" class="btn btn-link" value="Submit"  />
             </p>
        </div>
        </div>
        <div id="dvthankModal" style="padding-right:20px;"></div>
    <span class="icon-close"></span><span class="icon-close"></span></div>

<%--</div>--%>
<div style="top: 220px; left: 280px; width: 160px;" class="login_registration" id="divRecentRatings"></div>

<div id="wait_icon" class="font" style="width: 400px; height: 150px; display: none;">
    <img src="<%=mshost%>images/common/face1.gif">
 </div>
<div class="analyse-rating hide" >
    <div id="dvAnalyseRating">

    </div>
</div>


<div id="div2" style="display: none">
    <div class="confirmationbox">
        <span>Thank you for rating this Product</span>
    </div>
</div>
<div id="Div3" class="popuplayer1" style="display: none;">
    <div class="bdr-tb"></div>
    <div class="bdr-lr"></div>
    <div class="top-left"></div>
    <div class="top-right"></div>
    <div class="bottom-right"></div>
    <div class="bottom-left"></div>
    <div class="inner1">
        <div id="Div4"></div>
    </div>
</div>


<div id="writereviewpanel2" style="background: #ffffff url(/Images/COMMON/loading_ajax.gif) no-repeat 50% 80%; display: none;">
</div>
<script type="text/javascript">
    $(".AjxLayrClose").click(function() {$("#popuplayer1").hide(); 
        
        if('<%=orderid%>' !== "") { 
            window.location.href='<%=mshost %>';
        }
        else if(isver_corp === 1){
            window.location.href='<%=mshost %>';
        }
        else if(urlredirectTo!= undefined && urlredirectTo.indexOf('ratereview')!=-1) { 
            urlredirectTo = urlredirectTo.replace('-ratereview','').replace('&ratereview=1','');
        }
    }
 );
if($('#ctl00_ctl00_ContentPlaceHolderFooter_ContentPlaceHolderBody_customheader_proddet').length>0)
{
    $('#ctl00_ctl00_ContentPlaceHolderFooter_ContentPlaceHolderBody_customheader_proddet').parent().children('table').attr('width','500');
}

</script>
<script type="text/javascript">
    var broswer;
    browser = navigator.appName; 
    var CatName = "<%=CatName%>";
    var isver_corp="<%=isverified%>";
    var edit_ver_rev="<%=EditVerRev%>";

    var CatId = "<%=Cid%>";
    var cidOfuserreview = "<%=cidOfuserreview%>";
    var cidOfuserreview1 = "<%=cidOfuserreview%>";
    var lt2 = document.getElementById("<%=lt.ClientID%>").value;
    var lng2 = document.getElementById("<%=lngd.ClientID%>").value;
    var mshost = '<%=mshost%>';
    //callspecs(parent)
    var mergedprods='<%= mergedprods%>';
    var pid = "<%=cid%>";
    var ismerge_new = '<%=IsmergeNew%>';
    var check_corp = '<%=CheckCorp%>';
    var ddlYear;
    var isdocloaded = 0;
    var vdrmsg='<%=ConfigurationManager.appsettings("vdrmsg")%>';
    var drmsg='<%=ConfigurationManager.appsettings("drmsg")%>';                  
    var red_ver_url='<%=Session("new_ver_url")%>';  
    var mshostver='<%=mshost%>';
    var strSession = <%=Session("id")%>;
    var cid=<%=cidOfuserreview%>;
    var isedit = <%=isedit %>;
    var editreview=<%=editreview%>;
    var orderid='<%=orderid%>';
    var ver_rev_id='<%=VerRevId%>';
    var isbot='<%=IsBot %>';
    var merge_parent= '<%=objProduct.mergeparent%>';
    var name=$('<%= txtName.ClientID%>').value;
    var email=$('<%= txtMail.ClientID%>').value;
    var tele=$('<%= txtMob.ClientID%>').value;
    var dvqerror = '<%= dvQuoteError.ClientID%>';
    var name = '<%=Username1.Replace("'", "")%>';
    var msid = '<%=LoginName%>';
    var emai = '<%=StralertEmail%>';
    var nameGetRoadPrice='';
    var emailGetRoadPrice='';
    var teleGetRoadPrice='';
    try{
        nameGetRoadPrice=<%= txtName.ClientID%>;
    emailGetRoadPrice=<%= txtMail.ClientID%>; 
        teleGetRoadPrice=<%= txtMob.ClientID%>;
    }catch(e){}

var loc=window.location.hash;
if(loc=='#writerev')
{
            <% if Session("corporateName") is nothing andalso Session("id") > 0 then %>
    WriteReview();
            <% else %>
    window.location.href='<%=mshost %>';
    <% end if %>
           
}

        function toggle_visibility() {
         
            var e = document.getElementById('ddShare');
            if (e.style.display === 'block' || e.style.display === '') {
                e.style.display = 'none';
            }
            else {
                e.style.display = 'block';
            }
        }

 </script>  
</div>
