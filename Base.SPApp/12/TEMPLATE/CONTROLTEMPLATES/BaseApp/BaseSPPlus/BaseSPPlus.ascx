<%@ Control Language="C#" CodeBehind="BaseSPPlusControl.cs" Inherits="Base.SPApp.WebSite.Usercontrols.BaseSPPlusControl, Base.SPApp.WebSite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=03b678c7aa29b6cb" %>

<script type="text/javascript">
    $(function () {
		var $spserviceContainer = $('.spservice-container');
		
		var $loadBtn = $spserviceContainer.find('[data-action=load-lists]');
		var $tbodyResults = $spserviceContainer.find('[data-result=load-lists]');
		var results = [];
		
		try
		{
			var sourceTpl = $('#result-template').html();
			var compiledTpl = Handlebars.compile(sourceTpl); 
		}
		catch (ex)
		{
			console.log(ex);
		}
		
		// load lists btn
		$loadBtn.on('click', function(e) {
			e.preventDefault();
			
			$tbodyResults.html('');
			
			$SP().lists(function(lists) {
				results = lists;
				
				resultsRender(results, $tbodyResults, compiledTpl, registeredActions);
			});
		});
		
    });
	
	var resultsRender = function(collection, $container, hdlTemplate, callback)
	{
		
		try
		{
			for (var i = 0; i < collection.length; i++)
			{
				$container.append(
					hdlTemplate(collection[i])
				);
			}
			
			if(callback != undefined)
			{
				callback();
			}
		}
		catch(ex)
		{
			console.log("resultsRender function error. \n" + ex);
		}
		
	};
	
	var registeredActions = function() {
		
		var $loadListItemsBtn = $("[data-action=getItems]");
		
		$loadListItemsBtn.on('click', function(e) {
			e.preventDefault();
			
			var results = [];
			
			var $curItem = $(this);
			var listName = $curItem.data("item-name");
			var $listItemsContainer = $('tr[data-item-name="' + listName + '"]');
			
			$listItemsContainer.html('');
			
			try
			{
				var sourceTpl = $('#item-template').html();
				var compiledTpl = Handlebars.compile(sourceTpl); 
			}
			catch (ex)
			{
				console.log(ex);
			}
			
			$SP().list(listName).get(function(data) {
				results = convertItemsNodeList(data);
				
				resultsRender(results, $listItemsContainer, compiledTpl);
				$listItemsContainer.show();
			});
		});
		
	};
	
	var convertItemsNodeList = function(collection) {
		var converted = [];
		
		for(var i = 0; i < collection.length; i++)
		{
			var convertedObject = {
				'ID': collection[i].getAttribute('ID'),
				'Title': collection[i].getAttribute('Title'),
			};
		
			converted.push(convertedObject);
		}
		
		return converted;
	};
</script>

<script id="result-template" type="text/x-handlebars-template">
	<tr>
		<td>
			{{Name}}
		</td>
		<td>
			{{Description}}
		</td>
		<td>
			<a class="btn btn-primary" href="{{Url}}" target="_blank" role="button">View</a>
			<button data-item-name="{{Name}}" data-action="getItems" class="btn btn-sucess" type="button">Items</a>
		</td>
	</tr>
	<tr data-item-name="{{Name}}" class="active" style="display:none;">
		<!-- item-template -->
	</tr>
</script>

<script id="item-template" type="text/x-handlebars-template">
	<div>
		<span>
			{{ID}}
		</span>
		<span>
			{{Title}}
		</span>
	</div>
</script>

<div class="spservice-container">
	<button data-action="load-lists" class="btn btn-default" type="button">Load lists</button>

	<table class="table">
		<thead>
			<th>Name</th>
			<th>Description</th>
			<th>Actions</th>
		</thead>
		<tbody data-result="load-lists">
			<!-- list of all lists -->
		</tbody>
	</table>
</div>

