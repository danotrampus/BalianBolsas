/**
Core script to handle the entire theme and core functions
**/
var QuickSidebar = function () {

    var chat = $.connection.chatHub;

    //Handles chat
    var initChat = function () {
        
        chat.client.OnlineStatus = function (connectionId, userList) {
            //console.log("Usuarios Actualizados " + connectionId);
            var loggedUserId = $(".dropdown-user").attr("data-usuarioid");
            $("#ulOnlineUsers").html("");
            for (var i = 0; i < userList.length; i++) {
                var user = userList[i];
                if(loggedUserId != user.Id){
                    $("#ulOnlineUsers").append("<li class='media' data-usuarioId='" + user.Id + "'>" +
                                                    "<img class='media-object' src='/Content/admin/layout/img/avatar.png' alt='...'>" +
                                                    "<div class='media-body'>" +
                                                        "<h4 class='media-heading'>" + user.NombreUsuario + "</h4>" +
                                                        "<div class='media-heading-sub'>" +
                                                            user.Nombre + " " + user.Apellido +
                                                        "</div>" +
                                                    "</div>" +
                                                "</li>");
                }
            }
            handleQuickSidebarChat();
        };

        chat.client.joined = function (connectionId, userList) {
            //console.log("Conectado " + connectionId);
            var loggedUserId = $(".dropdown-user").attr("data-usuarioid");
            $("#ulOnlineUsers").html("");
            for (var i = 0; i < userList.length; i++) {
                var user = userList[i];
                if (loggedUserId != user.Id) {
                    $("#ulOnlineUsers").append("<li class='media' data-usuarioId='" + user.Id + "'>" +
                                                    "<img class='media-object' src='/Content/admin/layout/img/avatar.png' alt='...'>" +
                                                    "<div class='media-body'>" +
                                                        "<h4 class='media-heading'>" + user.NombreUsuario + "</h4>" +
                                                        "<div class='media-heading-sub'>" +
                                                            user.Nombre + " " + user.Apellido +
                                                        "</div>" +
                                                    "</div>" +
                                                "</li>");
                }
            }
            handleQuickSidebarChat();
        };

        chat.client.setChatWindow = function (strGroupName, strChatTo, listaMensajes) {
            var userLi = $('.page-quick-sidebar-wrapper').find(".page-quick-sidebar-chat-users .media-list > .media[data-usuarioid='" + strChatTo + "'] > .media-status").remove();
            var wrapperChat = $('.page-quick-sidebar-wrapper').find('.page-quick-sidebar-content-item-shown');
            wrapperChat.attr('data-nombregrupo', strGroupName);
            wrapperChat.attr('data-usuarioid', strChatTo);

            var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
            chatContainer.html("");
            for (var i = 0; i < listaMensajes.length; i++) {
                var mensaje = listaMensajes[i];
                var message = preparePost(mensaje.EntradaSalida, mensaje.FechaHoraFormateada, mensaje.Usuario.NombreUsuario, 'avatar2', mensaje.Mensaje);
                message = $(message);
                chatContainer.append(message);
            }
            
            var getLastPostPos = function () {
                var height = 0;
                chatContainer.find(".post").each(function () {
                    height = height + $(this).outerHeight();
                });

                return height;
            };

            chatContainer.slimScroll({
                scrollTo: getLastPostPos()
            });

        };

        chat.client.addMessage = function (message, groupName, fromId, fromUserName) {
            var wrapperChat = $('.page-quick-sidebar-wrapper').find(".page-quick-sidebar-content-item-shown[data-usuarioid='" + fromId + "']");
            if(wrapperChat.length == 0){
                var userLi = $('.page-quick-sidebar-wrapper').find(".page-quick-sidebar-chat-users .media-list > .media[data-usuarioid='" + fromId + "']");
                if(userLi.length > 0){
                    if (userLi.find(".media-status").length == 0) {
                        userLi.prepend("<div class='media-status'>" +
					                    "<span class='badge badge-success'>1</span>" +
							           "</div>")
                    }else{
                        badge = userLi.find(".badge");
                        count = parseInt(badge.text()) + 1;
                        badge.html(count);
                    }
                }
            } else {
                var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
                var time = new Date();
                var message = preparePost('in', (time.getHours() + ':' + time.getMinutes()), fromUserName, 'avatar2', message);
                message = $(message);
                chatContainer.append(message);
                var getLastPostPos = function () {
                    var height = 0;
                    chatContainer.find(".post").each(function () {
                        height = height + $(this).outerHeight();
                    });

                    return height;
                };

                chatContainer.slimScroll({
                    scrollTo: getLastPostPos()
                });
            }
        };

        $.connection.hub.start(function () {
            //console.log("Conectando...");
            //console.log(chat.server.getAllOnlineStatus());
        });
    };

    var preparePost = function (dir, time, name, avatar, message) {
        var tpl = '';
        tpl += '<div class="post ' + dir + '">';
        tpl += '<img class="avatar" alt="" src="/Content/admin/layout/img/avatar.png"/>';
        tpl += '<div class="message">';
        tpl += '<span class="arrow"></span>';
        tpl += '<a href="#" class="name">'+ name +'</a>&nbsp;';
        tpl += '<span class="datetime">' + time + '</span>';
        tpl += '<span class="body">';
        tpl += message;
        tpl += '</span>';
        tpl += '</div>';
        tpl += '</div>';

        return tpl;
    };

    // Handles quick sidebar toggler
    var handleQuickSidebarToggler = function () {
        // quick sidebar toggler
        $('.top-menu .dropdown-quick-sidebar-toggler a, .page-quick-sidebar-toggler').click(function (e) {
            $('body').toggleClass('page-quick-sidebar-open'); 
        });
    };

    // Handles quick sidebar chats
    var handleQuickSidebarChat = function () {
        var wrapper = $('.page-quick-sidebar-wrapper');
        var wrapperChat = wrapper.find('.page-quick-sidebar-chat');

        var initChatSlimScroll = function () {
            var chatUsers = wrapper.find('.page-quick-sidebar-chat-users');
            var chatUsersHeight;

            chatUsersHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

            // chat user list 
            Metronic.destroySlimScroll(chatUsers);
            chatUsers.attr("data-height", chatUsersHeight);
            Metronic.initSlimScroll(chatUsers);

            var chatMessages = wrapperChat.find('.page-quick-sidebar-chat-user-messages');
            var chatMessagesHeight = chatUsersHeight - wrapperChat.find('.page-quick-sidebar-chat-user-form').outerHeight() - wrapperChat.find('.page-quick-sidebar-nav').outerHeight();

            // user chat messages 
            Metronic.destroySlimScroll(chatMessages);
            chatMessages.attr("data-height", chatMessagesHeight);
            Metronic.initSlimScroll(chatMessages);
        };

        initChatSlimScroll();
        Metronic.addResizeHandler(initChatSlimScroll); // reinitialize on window resize

        wrapper.find('.page-quick-sidebar-chat-users .media-list > .media').click(function () {
            chat.server.createGroup($(this).attr('data-usuarioid'));
            wrapperChat.addClass("page-quick-sidebar-content-item-shown");
        });

        wrapper.find('.page-quick-sidebar-chat-user .page-quick-sidebar-back-to-list').click(function () {
            wrapperChat.attr('data-nombregrupo', "");
            wrapperChat.attr('data-usuarioid', "");
            wrapperChat.removeClass("page-quick-sidebar-content-item-shown");
        });

        var handleChatMessagePost = function (e) {
            e.preventDefault();

            var chatContainer = wrapperChat.find(".page-quick-sidebar-chat-user-messages");
            var input = wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control');

            var text = input.val();
            if (text.length === 0) {
                return;
            }

            //var preparePost = function(dir, time, name, avatar, message) {
            //    var tpl = '';
            //    tpl += '<div class="post '+ dir +'">';
            //    tpl += '<img class="avatar" alt="" src="' + Layout.getLayoutImgPath() + avatar +'.jpg"/>';
            //    tpl += '<div class="message">';
            //    tpl += '<span class="arrow"></span>';
            //    tpl += '<a href="#" class="name">Bob Nilson</a>&nbsp;';
            //    tpl += '<span class="datetime">' + time + '</span>';
            //    tpl += '<span class="body">';
            //    tpl += message;
            //    tpl += '</span>';
            //    tpl += '</div>';
            //    tpl += '</div>';

            //    return tpl;
            //};

            // handle post
            var time = new Date();
            var message = preparePost('out', (time.getHours() + ':' + time.getMinutes()), "Yo", 'avatar3', text);
            message = $(message);
            chatContainer.append(message);

            chat.server.send(text, wrapper.find('.page-quick-sidebar-content-item-shown').attr('data-nombregrupo'));

            var getLastPostPos = function() {
                var height = 0;
                chatContainer.find(".post").each(function() {
                    height = height + $(this).outerHeight();
                });

                return height;
            };           

            chatContainer.slimScroll({
                scrollTo: getLastPostPos()
            });

            input.val("");

            // simulate reply
            //setTimeout(function(){
            //    var time = new Date();
            //    var message = preparePost('in', (time.getHours() + ':' + time.getMinutes()), "Ella Wong", 'avatar2', 'Lorem ipsum doloriam nibh...');
            //    message = $(message);
            //    chatContainer.append(message);

            //    chatContainer.slimScroll({
            //        scrollTo: getLastPostPos()
            //    });
            //}, 3000);
        };

        wrapperChat.find('.page-quick-sidebar-chat-user-form .btn').click(handleChatMessagePost);
        wrapperChat.find('.page-quick-sidebar-chat-user-form .form-control').keypress(function (e) {
            if (e.which == 13) {
                handleChatMessagePost(e);
                return false;
            }
        });
    };

    // Handles quick sidebar tasks
    //var handleQuickSidebarAlerts = function () {
    //    var wrapper = $('.page-quick-sidebar-wrapper');
    //    var wrapperAlerts = wrapper.find('.page-quick-sidebar-alerts');

    //    var initAlertsSlimScroll = function () {
    //        var alertList = wrapper.find('.page-quick-sidebar-alerts-list');
    //        var alertListHeight;

    //        alertListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

    //        // alerts list 
    //        Metronic.destroySlimScroll(alertList);
    //        alertList.attr("data-height", alertListHeight);
    //        Metronic.initSlimScroll(alertList);
    //    };

    //    initAlertsSlimScroll();
    //    Metronic.addResizeHandler(initAlertsSlimScroll); // reinitialize on window resize
    //};

    // Handles quick sidebar settings
    //var handleQuickSidebarSettings = function () {
    //    var wrapper = $('.page-quick-sidebar-wrapper');
    //    var wrapperAlerts = wrapper.find('.page-quick-sidebar-settings');

    //    var initSettingsSlimScroll = function () {
    //        var settingsList = wrapper.find('.page-quick-sidebar-settings-list');
    //        var settingsListHeight;

    //        settingsListHeight = wrapper.height() - wrapper.find('.nav-justified > .nav-tabs').outerHeight();

    //        // alerts list 
    //        Metronic.destroySlimScroll(settingsList);
    //        settingsList.attr("data-height", settingsListHeight);
    //        Metronic.initSlimScroll(settingsList);
    //    };

    //    initSettingsSlimScroll();
    //    Metronic.addResizeHandler(initSettingsSlimScroll); // reinitialize on window resize
    //};

    return {

        init: function () {
            initChat();
            //layout handlers
            handleQuickSidebarToggler(); // handles quick sidebar's toggler
            //handleQuickSidebarChat(); // handles quick sidebar's chats
            //handleQuickSidebarAlerts(); // handles quick sidebar's alerts
            //handleQuickSidebarSettings(); // handles quick sidebar's setting
        }
    };

}();