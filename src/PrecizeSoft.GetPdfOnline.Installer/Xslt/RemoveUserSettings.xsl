<?xml version="1.0" ?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">

  <!-- Copy all attributes and elements to the output. -->
  <xsl:template match="@*|*">
    <xsl:copy>
      <xsl:apply-templates select="@*" />
      <xsl:apply-templates select="*" />
    </xsl:copy>
  </xsl:template>

  <xsl:output method="xml" indent="yes" />

  <xsl:key name="usersettingsjson-search" match="wix:Component[substring(wix:File/@Source, string-length(wix:File/@Source) - 15) = 'usersettings.txt']" use="@Id" />
  <xsl:template match="wix:Component[key('usersettingsjson-search', @Id)]" />
  <xsl:template match="wix:ComponentRef[key('usersettingsjson-search', @Id)]" />
</xsl:stylesheet>