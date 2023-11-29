function getTable(tableName) {
   
    if (!$.fn.DataTable.isDataTable(tableName)) {

        $(tableName + " thead tr")
            .clone(true)
            .addClass("filters")
            .appendTo(tableName + " thead");

        var table = $(tableName).DataTable({

            "language": {
                "url": "https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            },
            columnDefs: [
                { width: 100, targets: "_all" }
            ],
            scrollX: true,
            retrieve: true,
            orderCellsTop: true,
            fixedHeader: true,
            searching: true,
            pagingType: 'numbers',
            initComplete: function () {
                var api = this.api();

            
                api
                    .columns()
                    .eq(0)
                    .each(function (colIdx) {
                      
                        var cell = $(".filters th").eq(
                            $(api.column(colIdx).header()).index()

                        );

                        var title = $(cell).text();
                        if (title != "") {
                            $(cell).html('<input type="text" placeholder="' + title + '" />');
                        }


                       
                        $(
                            'input',
                            $(".filters th").eq($(api.column(colIdx).header()).index())
                        )
                            .off('keyup change')
                            .on('change', function (e) {
                             
                                $(this).attr('title', $(this).val());
                                var regexr = '({search})';
                                $(this).parents('th').find('select').val();

                            
                                var cursorPosition = this.selectionStart;
                              
                                api
                                    .column(colIdx)
                                    .search(
                                        this.value != ''
                                            ? regexr.replace('{search}', '(((' + this.value + ')))')
                                            : '',
                                        this.value != '',
                                        this.value == ''
                                    )
                                    .draw();
                            })

                            .on('keyup', function (e) {

                                //$(".filters th input").each(function () {
                                //    console.log($(this).attr("title"))
                                //}),

                                //if ($("#userTable_info").text().indexOf("Kayıt Yok") == -1) {
                                //    $("#tableResult").text("");
                                //}
                                //$("#tableResult").text($("#userTable_info").text());

                                e.stopPropagation();

                                $(this).trigger('change');
                                $(this)
                                    .focus()[0]
                                    .setSelectionRange(cursorPosition, cursorPosition);
                            });
                    });
            },
        });

    }

};