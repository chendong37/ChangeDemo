<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Change.Web.Admin.News" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="on"><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>   


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

<!--内容-->
<div class="right_style">
  <!--内容详细-->
   <div class="title_style"><em></em>商品专区</div>
   <div class="content_style">
    <div class="Products_area_style">
     <div class="Add_product_style"><a href="商品专区-发布商品.html" class="Add_btn">发布商品</a> </div>
     
     <div class="Products_list_style">
      <table>
       <thead>
        <tr class="title">
         <td class="checkbox_style"><input name="" type="checkbox" value=""></td>
         <td class="title_name">商品标题</td>
         <td class="inventory">商品库存</td>
         <td class="status">商品转态</td>
         <td class="operating">操作</td>
         </tr>
        </thead>
       <tbody>
        <tr>
          <td><input name="" type="checkbox" value=""></td>
          <td><a href="#">悦含小凳子便携小马扎钓鱼凳子牛津布地铁火车小板凳折叠凳</a></td>
          <td>3456</td>
          <td>审核失败</td>
          <td class="operating_btn relative">
           <div class="inventory_style">
              <input name="" type="text" class="add_Number"><input name="1" type="submit" value="确认" class="confirm_btn"> <a href="#" class="cancel"><em class="cancel-icon"></em></a>
           </div>
          <a href="#" class="fzxx_btn">复制信息</a><a href="商品专区-评价管理.html" class="pjgl_btn">评价管理</a><a href="#" class="szkc_btn">设置库存</a><a href="#" class="sj_btn">删除</a></td>
        </tr>
          <tr>
          <td><input name="" type="checkbox" value=""></td>
          <td><a href="#">悦含小凳子便携小马扎钓鱼凳子牛津布地铁火车小板凳折叠凳</a></td>
          <td>3456</td>
          <td>审核失败</td>
          <td class="operating_btn relative">
          <div class="inventory_style">
              <input name="" type="text" class="add_Number"><input name="1" type="submit" value="确认" class="confirm_btn"> <a href="#" class="cancel"><em class="cancel-icon"></em></a>
           </div>
          <a href="#" class="fzxx_btn">复制信息</a><a href="商品专区-评价管理.html" class="pjgl_btn">评价管理</a><a href="#" class="szkc_btn">设置库存</a><a href="#" class="sj_btn">删除</a></td>
        </tr>
          <tr>
          <td><input name="" type="checkbox" value=""></td>
          <td><a href="#">悦含小凳子便携小马扎钓鱼凳子牛津布地铁火车小板凳折叠凳</a></td>
          <td>3456</td>
          <td>审核中</td>
          <td class="operating_btn relative">
          <div class="inventory_style">
              <input name="" type="text" class="add_Number"><input name="1" type="submit" value="确认" class="confirm_btn"> <a href="#" class="cancel"><em class="cancel-icon"></em></a>
           </div>
          <a href="#" class="fzxx_btn">复制信息</a><a href="商品专区-评价管理.html" class="pjgl_btn">评价管理</a><a href="#" class="szkc_btn">设置库存</a><a href="#" class="sj_btn" id="sj_btn">上架</a></td>
        </tr>
          <tr>
          <td><input name="" type="checkbox" value=""></td>
          <td><a href="#">悦含小凳子便携小马扎钓鱼凳子牛津布地铁火车小板凳折叠凳</a></td>
          <td>3456</td>
          <td>审核中</td>
          <td class="operating_btn relative">
          <div class="inventory_style">
              <input name="" type="text" class="add_Number"><input name="1" type="submit" value="确认" class="confirm_btn"> <a href="#" class="cancel"><em class="cancel-icon"></em></a>
           </div>
          <a href="#" class="fzxx_btn">复制信息</a><a href="商品专区-评价管理.html" class="pjgl_btn">评价管理</a><a href="#" class="szkc_btn">设置库存</a><a href="#" class="sj_btn">上架</a></td>
        </tr>  <tr>
          <td><input name="" type="checkbox" value=""></td>
          <td><a href="#">悦含小凳子便携小马扎钓鱼凳子牛津布地铁火车小板凳折叠凳</a></td>
          <td>3456</td>
          <td>有效</td>
          <td class="operating_btn relative">
           <div class="inventory_style">
              <input name="" type="text" class="add_Number"><input name="1" type="submit" value="确认" class="confirm_btn"> <a href="#" class="cancel"><em class="cancel-icon"></em></a>
           </div>
          <a href="#" class="fzxx_btn">复制信息</a><a href="商品专区-评价管理.html" class="pjgl_btn">评价管理</a><a href="#" class="szkc_btn">设置库存</a><a href="#" class="sj_btn">上架</a></td>
        </tr>
       </tbody>
      </table>
      <div class="page_style">每页显示<select name="" size="1"> <option value="1">10</option></select>共3页 共28条，当前第1/3页 <a href="#">首页</a><a href="#">上一页</a><a href="#">下一页</a><a href="#">尾页</a></div>
     </div>
    </div>  
  </div>
 </div>
</div>
</asp:Content>
