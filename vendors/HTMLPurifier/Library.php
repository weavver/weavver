<?
  include "HTMLPurifier.standalone.php";
 
  function Purify($dirty_html)
  {
      $config = HTMLPurifier_Config::createDefault();
      $config->set('AutoFormat.Linkify', 'true');
      
      $config->set('URI.AllowedSchemes', array ('http' => true, 'https' => true, 'mailto' => true, 'ftp' => true, 'nntp' => true, 'news' => true, 'tel' => true));
      
      $purifier = new HTMLPurifier($config);
      $clean_html = $purifier->purify( $dirty_html );
      echo $clean_html;
  }

?>