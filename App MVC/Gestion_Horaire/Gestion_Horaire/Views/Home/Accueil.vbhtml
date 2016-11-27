﻿<head>
    <script type="text/javascript" src="global_vars.js"></script>
    <title>Maquette - Gestion des horaires</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" media="screen"
          href="http://tarruda.github.com/bootstrap-datetimepicker/assets/css/bootstrap-datetimepicker.min.css">
    <script type="text/javascript" src="creationTableau.js"></script>
</head>
<body>

    <div class="row">
        <div class="div-col-xs-2 col-xs-offset-5">
            <!--      <div id="datetimepicker" class="input-append date" onchange="console.log('test')">
                     <input type="text" id="date_sem" ></input>
                     <script>
                     let field = document.getElementById("date_sem");
                     let now = new Date(Date.now());
                     console.log(now);
                     field.value = now.getFullYear()+"-"+String("00" + (now.getMonth()+1)).slice(-2)+"-"+String("00" + now.getDate()).slice(-2);


                     </script>
                     <span class="add-on">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                     </span>
                  </div>-->
            <script type="text/javascript"
                    src="http://cdnjs.cloudflare.com/ajax/libs/jquery/1.8.3/jquery.min.js">
            </script>

            <script type="text/javascript"
                    src="http://tarruda.github.com/bootstrap-datetimepicker/assets/js/bootstrap-datetimepicker.min.js">
            </script>

            <script type="text/javascript">
               var formatDate = 'yyyy-MM-dd';
               $('#datetimepicker').datetimepicker({
               format: 'yyyy-MM-dd',
               language: 'en-US'
               });
            </script>

        </div>
        <!-- <input type="button" value="Go!" onclick="refreshApp()" id="btnGo"><br><br> -->
        <h1 id="semaine_du"></h1>
    </div>

    <div id="container">
        <canvas id="app_cvs" width="900px" height="600px"></canvas>
    </div>
    <script>refreshApp(); creerCanvas(); </script>
    <script type="text/javascript" src="./scripts/tests.js"></script>
    <script src="https://code.jquery.com/jquery-3.1.1.js"
            integrity="sha256-16cdPddA6VdVInumRGo6IbivbERE8p7CQR3HzTBuELA="
            crossorigin="anonymous"></script>
    <script type="text/javascript" src="global_vars.js"></script>
    <br><br>

</body>
