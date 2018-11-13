<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/Orderlist">
		<html>
			<head>
				<title>OrderList</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="OrderName">
						<li>
							<xsl:value-of select="OrderNumber" />
						</li>
					</xsl:for-each>
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
